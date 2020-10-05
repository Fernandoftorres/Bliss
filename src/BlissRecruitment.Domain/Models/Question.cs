using BlissRecruitment.Domain.Core.Domain;
using System;
using System.Collections.Generic;

namespace BlissRecruitment.Domain.Models
{
    public class Question : Entity, IAggregateRoot
    {
        public Question(long id, string questionDescription, string imageUrl, string thumbUrl, DateTime publishedAt)
        {
            Id = id;
            QuestionDescription = questionDescription;
            ImageUrl = imageUrl;
            ThumbUrl = thumbUrl;
            PublishedAt = publishedAt;
        }

        // Empty constructor for EF
        protected Question() { }

        public string QuestionDescription { get; private set; }

        public string ImageUrl { get; private set; }

        public string ThumbUrl { get; private set; }

        public DateTime PublishedAt { get; private set; }

        public virtual ICollection<QuestionChoice> QuestionChoices { get; set; }
    }
}