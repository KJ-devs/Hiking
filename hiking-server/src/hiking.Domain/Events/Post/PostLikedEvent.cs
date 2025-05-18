using Hiking.Domain.Common;

namespace Hiking.Domain.Events
{
    public class PostLikedEvent : DomainEvent
    {
        public Guid PostId { get; }
        public Guid UserId { get; }

        public PostLikedEvent(Guid postId, Guid userId)
        {
            PostId = postId;
            UserId = userId;
        }
    }
}