using System;
using BlissRecruitment.Domain.Commands.Validations;
using BlissRecruitment.Domain.Core.Messaging;

namespace BlissRecruitment.Domain.Commands
{
    public class RegisterNewQuestionCommand : QuestionCommand
    {
        public RegisterNewQuestionCommand(string questionDescription, 
                                          string imageUrl, 
                                          string thumbUrl,
                                          string[] choices)
        {
            QuestionDescription = questionDescription;
            ImageUrl = imageUrl;
            ThumbUrl = thumbUrl;
            Choices = choices;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewQuestionCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}