using BlissRecruitment.Domain.Core.Domain;

namespace BlissRecruitment.Domain.Models
{
    public class QuestionChoice : Entity, IAggregateRoot
    {
        public QuestionChoice(long id, long questionId, string choice, int votes)
        {
            Id = id;
            QuestionId = questionId;
            Choice = choice;
            Votes = votes;
        }

        // Empty constructor for EF
        protected QuestionChoice() { }

        public long QuestionId { get; private set; }

        public string Choice { get; private set; }

        public int Votes { get; private set; }

        public Question Question { get; set; }
    }
}