using BlissRecruitment.Domain.Core.Messaging;
using BlissRecruitment.Domain.Models;
using System.Collections.Generic;

namespace BlissRecruitment.Domain.Commands
{
    public abstract class QuestionCommand : Command
    {
        public long Id { get; protected set; }

        public string QuestionDescription { get; protected set; }

        public string ImageUrl { get; protected set; }

        public string ThumbUrl { get; protected set; }

        public string[] Choices { get; protected set; }

        public ICollection<QuestionChoice> ChoicesUpdate { get; protected set; }
    }
}