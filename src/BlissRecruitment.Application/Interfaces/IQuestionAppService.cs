using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlissRecruitment.Application.ViewModels;
using FluentValidation.Results;

namespace BlissRecruitment.Application.Interfaces
{
    public interface IQuestionAppService : IDisposable
    {
        Task<IEnumerable<QuestionViewModel>> GetAll(string filter, int limit, int offset);
        Task<QuestionViewModel> GetById(long id);
        Task<QuestionViewModel> Register(RegisterQuestionViewModel registerQuestionViewModel);
        Task<QuestionViewModel> Update(UpdateQuestionViewModel questionViewModel);
        Task<ValidationResult> ShareUrl(string destination, string url);
    }
}
