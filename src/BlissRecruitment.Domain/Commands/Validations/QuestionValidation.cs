using FluentValidation;

namespace BlissRecruitment.Domain.Commands.Validations
{
    public abstract class QuestionValidation<T> : AbstractValidator<T> where T : QuestionCommand
    {
        protected void ValidateChoices()
        {
            RuleFor(c => c.Choices)
                .NotNull().WithMessage("Please ensure entered the questions")
                .Must(x => x.Length > 0).WithMessage("Please ensure entered the questions")
                .NotEmpty().WithMessage("Please ensure entered the questions");
        }

    }
}