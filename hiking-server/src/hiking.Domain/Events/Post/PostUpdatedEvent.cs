using Hiking.Domain.Common;
namespace Hiking.Domain.Events
{
    public class PostUpdatedEvent : DomainEvent
    {
        public Guid PostId { get; }
        public Guid AuthorId { get; }

        public PostUpdatedEvent(Guid postId, Guid authorId)
        {
            PostId = postId;
            AuthorId = authorId;
        }
    }
}