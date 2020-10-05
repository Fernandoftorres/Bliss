using System;
using System.Linq;
using System.Threading.Tasks;
using BlissRecruitment.Domain.Core.Data;
using BlissRecruitment.Domain.Core.Domain;
using BlissRecruitment.Domain.Core.Mediator;
using BlissRecruitment.Domain.Core.Messaging;
using BlissRecruitment.Domain.Models;
using BlissRecruitment.Infra.Data.Mappings;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace BlissRecruitment.Infra.Data.Context
{
    public sealed class BlissRecruitmentContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public BlissRecruitmentContext(DbContextOptions<BlissRecruitmentContext> options, IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionChoice> QuestionChoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfiguration(new QuestionMap());
            modelBuilder.ApplyConfiguration(new QuestionChoiceMap());

            PopulateData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void PopulateData(ModelBuilder modelBuilder)
        {
            int keyQuestion = 1;
            for (int i = 1; i <= 10; i++)
            {
                modelBuilder.Entity<Question>().HasData(
                    new Question(i, "Favourite programming language?",
                    "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)",
                    "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)",
                    DateTime.Now
                    ));
                modelBuilder.Entity<QuestionChoice>().HasData(
                    new QuestionChoice(keyQuestion, i, "Swift", 0),
                    new QuestionChoice(keyQuestion + 1, i, "Python", 0),
                    new QuestionChoice(keyQuestion + 2, i, "Objective-C", 0),
                    new QuestionChoice(keyQuestion + 3, i, "Ruby", 0)
                    );
                keyQuestion += 4;
            }
        }

        public async Task<bool> Commit()
        {
            await _mediatorHandler.PublishDomainEvents(this).ConfigureAwait(false);
            return await SaveChangesAsync() > 0;
        }
    }

    public static class MediatorExtension
    {
        public static async Task PublishDomainEvents<T>(this IMediatorHandler mediator, T ctx) where T : DbContext
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await mediator.PublishEvent(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
