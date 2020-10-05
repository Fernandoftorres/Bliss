namespace BlissRecruitment.Domain.Commands.Validations
{
    public class RegisterNewQuestionCommandValidation : QuestionValidation<RegisterNewQuestionCommand>
    {
        public RegisterNewQuestionCommandValidation()
        {
            ValidateChoices();
        }
    }
}