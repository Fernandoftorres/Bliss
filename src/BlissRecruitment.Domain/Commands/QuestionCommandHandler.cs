using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using BlissRecruitment.Domain.Core.Messaging;
using BlissRecruitment.Domain.Events;
using BlissRecruitment.Domain.Interfaces;
using BlissRecruitment.Domain.Models;
using FluentValidation.Results;
using MediatR;

namespace BlissRecruitment.Domain.Commands
{
    public class QuestionCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewQuestionCommand, ValidationResult>,
        IRequestHandler<UpdateQuestionCommand, ValidationResult>
    {
        private readonly IQuestionRepository _questionRepository;

        private readonly IQuestionChoiceRepository _questionChoiceRepository;

        public QuestionCommandHandler(IQuestionRepository questionRepository,
                                      IQuestionChoiceRepository questionChoiceRepository)
        {
            _questionRepository = questionRepository;
            _questionChoiceRepository = questionChoiceRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewQuestionCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var question = new Question(0, message.QuestionDescription, message.ImageUrl, message.ThumbUrl, DateTime.Now);

            if (await _questionRepository.GetByDescription(message.QuestionDescription) != null)
            {
                AddError("The question description has already exists.");
                return ValidationResult;
            }

            _questionRepository.Add(question);
            var result = await Commit(_questionRepository.UnitOfWork);

            if (result.IsValid)
            {
                foreach (var choice in message.Choices)
                {
                    _questionChoiceRepository.Add(new QuestionChoice(0, question.Id, choice, 0));
                }

                question.AddDomainEvent(new QuestionRegisteredEvent(question.Id, question.QuestionDescription,
                    question.ImageUrl, question.ThumbUrl, question.PublishedAt));

                return await Commit(_questionChoiceRepository.UnitOfWork);
            }

            return result;
        }

        public async Task<ValidationResult> Handle(UpdateQuestionCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var question = new Question(message.Id, message.QuestionDescription, message.ImageUrl, message.ThumbUrl, DateTime.Now);
            var existingQuestion = await _questionRepository.GetByDescription(question.QuestionDescription);

            if (existingQuestion != null && existingQuestion.Id != question.Id)
            {
                if (!existingQuestion.Equals(question))
                {
                    AddError("The question description has already exists.");
                    return ValidationResult;
                }
            }

            _questionChoiceRepository.RemoveChoices(question.Id);
            _questionRepository.Update(question);

            var result = await Commit(_questionRepository.UnitOfWork);

            if (result.IsValid)
            {
                foreach (QuestionChoice questionChoice in message.ChoicesUpdate)
                {
                    _questionChoiceRepository.Add(new QuestionChoice(0, question.Id, questionChoice.Choice, questionChoice.Votes));
                }

                question.AddDomainEvent(new QuestionUpdatedEvent(question.Id, question.QuestionDescription,
                    question.ImageUrl, question.ThumbUrl, question.PublishedAt));

                return await Commit(_questionChoiceRepository.UnitOfWork);
            }

            return result;
        }

        public void Dispose()
        {
            _questionRepository.Dispose();
        }
    }
}