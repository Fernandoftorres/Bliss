using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BlissRecruitment.Application.Interfaces;
using BlissRecruitment.Application.ViewModels;
using BlissRecruitment.Domain.Commands;
using BlissRecruitment.Domain.Core.Mediator;
using BlissRecruitment.Domain.Interfaces;
using FluentValidation.Results;

namespace BlissRecruitment.Application.Services
{
    public class QuestionAppService : IQuestionAppService
    {
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;
        private readonly IMediatorHandler _mediator;
        private readonly IEmailSender _emailSender;

        public QuestionAppService(IMapper mapper,
                                  IQuestionRepository questionRepository,
                                  IMediatorHandler mediator,
                                  IEmailSender emailSender)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
            _mediator = mediator;
            _emailSender = emailSender;
        }

        public async Task<IEnumerable<QuestionViewModel>> GetAll(string filter, int limit, int offset)
        {
            return _mapper.Map<IEnumerable<QuestionViewModel>>(await _questionRepository.GetAll(filter, limit, offset));
        }

        public async Task<QuestionViewModel> GetById(long id)
        {
            return _mapper.Map<QuestionViewModel>(await _questionRepository.GetById(id));
        }

        public async Task<QuestionViewModel> Register(RegisterQuestionViewModel registerQuestionViewModel)
        {
            var command = _mapper.Map<RegisterNewQuestionCommand>(registerQuestionViewModel);
            var result = await _mediator.SendCommand(command);

            if (result.IsValid)
            {
                return _mapper.Map<QuestionViewModel>(await _questionRepository.GetByDescription(registerQuestionViewModel.question));
            }

            return null;
        }

        public async Task<QuestionViewModel> Update(UpdateQuestionViewModel questionViewModel)
        {
            var updateCommand = _mapper.Map<UpdateQuestionCommand>(questionViewModel);
            var result = await _mediator.SendCommand(updateCommand);

            if (result.IsValid)
            {
                return _mapper.Map<QuestionViewModel>(await _questionRepository.GetById(questionViewModel.id));
            }

            return null;
        }

        public async Task<ValidationResult> ShareUrl(string destination, string url)
        {
            if (string.IsNullOrEmpty(destination) || string.IsNullOrEmpty(url))
            {
                var validation = new ValidationResult();
                validation.Errors.Add(new ValidationFailure(string.Empty, "Please ensure entered the email or url"));
                return validation;
            }

            await _emailSender.SendEmailAsync(destination, "Share Url", url);
            return new ValidationResult();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
