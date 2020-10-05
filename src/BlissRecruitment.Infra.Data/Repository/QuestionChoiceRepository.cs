using BlissRecruitment.Domain.Core.Data;
using BlissRecruitment.Domain.Interfaces;
using BlissRecruitment.Domain.Models;
using BlissRecruitment.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace BlissRecruitment.Infra.Data.Repository
{
    public class QuestionChoiceRepository : IQuestionChoiceRepository
    {
        protected readonly BlissRecruitmentContext Db;
        protected readonly DbSet<QuestionChoice> DbSet;

        public QuestionChoiceRepository(BlissRecruitmentContext context)
        {
            Db = context;
            DbSet = Db.Set<QuestionChoice>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public void Add(QuestionChoice questionChoice)
        {
            DbSet.Add(questionChoice);
        }

        public void RemoveChoices(long questionId)
        {
            DbSet.RemoveRange(DbSet.Where(x => x.QuestionId.Equals(questionId)).ToList());
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
