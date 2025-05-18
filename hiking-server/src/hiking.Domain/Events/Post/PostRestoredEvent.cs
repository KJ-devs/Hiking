using Hiking.Domain.Common;
namespace Hiking.Domain.Events
{
    public class PostRestoredEvent : DomainEvent
    {
        public Guid PostId { get; }
        public Guid AuthorId { get; }

        public PostRestoredEvent(Guid postId, Guid authorId)
        {
            PostId = postId;
            AuthorId = authorId;
        }
    }
}