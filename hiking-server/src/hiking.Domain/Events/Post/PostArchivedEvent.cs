using Hiking.Domain.Common;
namespace Hiking.Domain.Events
{
    public class PostArchivedEvent : DomainEvent
    {
        public Guid PostId { get; }
        public Guid AuthorId { get; }

        public PostArchivedEvent(Guid postId, Guid authorId)
        {
            PostId = postId;
            AuthorId = authorId;
        }
    }
}