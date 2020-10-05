using System;

namespace BlissRecruitment.Domain.Core.Messaging
{
    public abstract class Message
    {
        public string MessageType { get; protected set; }
        public long AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
