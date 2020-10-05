using System.Collections.Generic;
using System.Threading.Tasks;
using BlissRecruitment.Domain.Core.Data;
using BlissRecruitment.Domain.Models;

namespace BlissRecruitment.Domain.Interfaces
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Task<Question> GetById(long id);
        Task<Question> GetByDescription(string description);
        Task<IEnumerable<Question>> GetAll(string filter, int limit, int offset);

        void Add(Question question);
        void Update(Question question);
    }
}