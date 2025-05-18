using Hiking.Domain.Common;
namespace Hiking.Domain.Events
{
    public class PostUnlikedEvent : DomainEvent
    {
        public Guid PostId { get; }
        public Guid UserId { get; }

        public PostUnlikedEvent(Guid postId, Guid userId)
        {
            PostId = postId;
            UserId = userId;
        }
    }
}