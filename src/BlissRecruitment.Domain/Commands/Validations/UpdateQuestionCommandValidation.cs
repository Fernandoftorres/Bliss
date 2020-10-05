namespace BlissRecruitment.Domain.Commands.Validations
{
    public class UpdateQuestionCommandValidation : QuestionValidation<UpdateQuestionCommand>
    {
        public UpdateQuestionCommandValidation()
        {
            ValidateChoices();
        }
    }
}