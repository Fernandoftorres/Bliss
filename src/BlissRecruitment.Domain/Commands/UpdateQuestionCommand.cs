using System;
using System.Collections.Generic;
using BlissRecruitment.Domain.Commands.Validations;
using BlissRecruitment.Domain.Models;

namespace BlissRecruitment.Domain.Commands
{
    public class UpdateQuestionCommand : QuestionCommand
    {
        public UpdateQuestionCommand(long id,
                                     string questionDescription,
                                     string imageUrl,
                                     string thumbUrl,
                                     List<QuestionChoice> choices)
        {
            Id = id;
            QuestionDescription = questionDescription;
            ImageUrl = imageUrl;
            ThumbUrl = thumbUrl;
            ChoicesUpdate = choices;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateQuestionCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}