using BlissRecruitment.Domain.Core.Data;
using BlissRecruitment.Domain.Models;

namespace BlissRecruitment.Domain.Interfaces
{
    public interface IQuestionChoiceRepository : IRepository<QuestionChoice>
    {
        void Add(QuestionChoice questionChoice);
        void RemoveChoices(long questionId);
    }
}