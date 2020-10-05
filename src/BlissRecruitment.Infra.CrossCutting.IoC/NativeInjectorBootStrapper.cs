using BlissRecruitment.Application.Interfaces;
using BlissRecruitment.Application.Services;
using BlissRecruitment.Domain.Commands;
using BlissRecruitment.Domain.Core.Mediator;
using BlissRecruitment.Domain.Events;
using BlissRecruitment.Domain.Interfaces;
using BlissRecruitment.Domain.Models;
using BlissRecruitment.Infra.CrossCutting.Bus;
using BlissRecruitment.Infra.Data.Context;
using BlissRecruitment.Infra.Data.Repository;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BlissRecruitment.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped<IEmailSender, EmailSender>();

            // Application
            services.AddScoped<IQuestionAppService, QuestionAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<QuestionRegisteredEvent>, QuestionEventHandler>();
            services.AddScoped<INotificationHandler<QuestionUpdatedEvent>, QuestionEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewQuestionCommand, ValidationResult>, QuestionCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateQuestionCommand, ValidationResult>, QuestionCommandHandler>();

            // Infra - Data
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IQuestionChoiceRepository, QuestionChoiceRepository>();
            services.AddScoped<BlissRecruitmentContext>();
        }
    }
}