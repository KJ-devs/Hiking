
using Hiking.Domain.Common;
public class CommentRemovedEvent : DomainEvent
{
    public Guid PostId { get; }
    public Guid CommentId { get; }
    public Guid AuthorId { get; }

    public CommentRemovedEvent(Guid postId, Guid commentId, Guid authorId)
    {
        PostId = postId;
        CommentId = commentId;
        AuthorId = authorId;
    }
}