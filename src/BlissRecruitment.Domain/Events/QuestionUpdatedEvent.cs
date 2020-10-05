using BlissRecruitment.Domain.Core.Messaging;
using System;

namespace BlissRecruitment.Domain.Events
{
    public class QuestionUpdatedEvent : Event
    {
        public QuestionUpdatedEvent(long id, string questionDescription, string imageUrl, string thumbUrl, DateTime publishedAt)
        {
            Id = id;
            QuestionDescription = questionDescription;
            ImageUrl = imageUrl;
            ThumbUrl = thumbUrl;
            PublishedAt = publishedAt;
            AggregateId = id;
        }
        public long Id { get; set; }

        public string QuestionDescription { get; private set; }

        public string ImageUrl { get; private set; }

        public string ThumbUrl { get; private set; }

        public DateTime PublishedAt { get; private set; }
    }
}