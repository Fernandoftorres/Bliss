using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BlissRecruitment.Domain.Core.Data;
using BlissRecruitment.Domain.Interfaces;
using BlissRecruitment.Domain.Models;
using BlissRecruitment.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BlissRecruitment.Infra.Data.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        protected readonly BlissRecruitmentContext Db;
        protected readonly DbSet<Question> DbSet;

        public QuestionRepository(BlissRecruitmentContext context)
        {
            Db = context;
            DbSet = Db.Set<Question>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<Question> GetById(long id)
        {
            return await DbSet
                .Include(x => x.QuestionChoices)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Question>> GetAll(string filter, int limit, int offset)
        {
            IQueryable<Question> query = DbSet
                .Include(x => x.QuestionChoices)
                .AsQueryable<Question>();
            
            if (!string.IsNullOrEmpty(filter))
            {
                string lowerFilter = filter.ToLower();

                query = DbSet
                    .Where(x => x.QuestionDescription.ToLower().Contains(lowerFilter) ||
                                x.QuestionChoices.Any(y => y.Choice.ToLower().Contains(lowerFilter)));
            }

            return await query
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<Question> GetByDescription(string description)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.QuestionDescription == description);
        }

        public void Add(Question question)
        {
            DbSet.Add(question);
        }

        public void Update(Question question)
        {
            DbSet.Update(question);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
