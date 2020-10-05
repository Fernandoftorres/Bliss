using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace BlissRecruitment.Domain.Events
{
    public class QuestionEventHandler :
        INotificationHandler<QuestionRegisteredEvent>,
        INotificationHandler<QuestionUpdatedEvent>
    {
        public Task Handle(QuestionRegisteredEvent message, CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }

        public Task Handle(QuestionUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}