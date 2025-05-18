
using Hiking.Domain.Common;
public class CommentAddedEvent : DomainEvent
{
    public Guid PostId { get; }
    public Guid CommentId { get; }
    public Guid AuthorId { get; }

    public CommentAddedEvent(Guid postId, Guid commentId, Guid authorId)
    {
        PostId = postId;
        CommentId = commentId;
        AuthorId = authorId;
    }
}
