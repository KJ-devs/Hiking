using Hiking.Domain.ValueObjects;
using Hiking.Domain.Common;
using Hiking.Domain.Events;


namespace Hiking.Domain.Entities
{
    /// <summary>
    /// Représente une publication dans le système
    /// </summary>
    public class Post : AggregateRoot
    {
        // Propriétés
        public Guid Id { get; private set; }
        public Guid AuthorId { get; private set; }
        public PostContent Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ModifiedAt { get; private set; }
        public bool IsArchived { get; private set; }

        // Navigation properties
        public User Author { get; private set; }

        // Relations
        private readonly List<Comment> _comments = new();
        public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

        private readonly List<PostLike> _likes = new();
        public IReadOnlyCollection<PostLike> Likes => _likes.AsReadOnly();

        // Constructeur privé pour EF Core
        private Post() { }

        // Constructeur principal
        public Post(Guid id, Guid authorId, PostContent content)
        {
            Id = id;
            AuthorId = authorId;
            Content = content ?? throw new ArgumentNullException(nameof(content));
            CreatedAt = DateTime.UtcNow;
            IsArchived = false;

            AddDomainEvent(new PostCreatedEvent(id, authorId));
        }

        // Méthodes de domaine
        public void Update(PostContent newContent)
        {
            if (IsArchived)
                throw new InvalidOperationException("Une publication archivée ne peut pas être modifiée");

            Content = newContent ?? throw new ArgumentNullException(nameof(newContent));
            ModifiedAt = DateTime.UtcNow;

            AddDomainEvent(new PostUpdatedEvent(Id, AuthorId));
        }

        public void Archive()
        {
            if (IsArchived)
                return;

            IsArchived = true;

            AddDomainEvent(new PostArchivedEvent(Id, AuthorId));
        }

        public void Restore()
        {
            if (!IsArchived)
                return;

            IsArchived = false;

            AddDomainEvent(new PostRestoredEvent(Id, AuthorId));
        }

        public Comment AddComment(Guid id, Guid userId, string content)
        {
            if (IsArchived)
                throw new InvalidOperationException("Impossible d'ajouter un commentaire à une publication archivée");

            var comment = new Comment(id, Id, userId, content);
            _comments.Add(comment);

            AddDomainEvent(new CommentAddedEvent(Id, comment.Id, userId));

            return comment;
        }

        public void RemoveComment(Comment comment)
        {
            _comments.Remove(comment);

            AddDomainEvent(new CommentRemovedEvent(Id, comment.Id, comment.AuthorId));
        }

        public void AddLike(Guid userId)
        {
            if (IsArchived)
                throw new InvalidOperationException("Impossible d'aimer une publication archivée");

            if (_likes.Any(l => l.UserId == userId))
                return;

            var like = new PostLike(Id, userId);
            _likes.Add(like);

            AddDomainEvent(new PostLikedEvent(Id, userId));
        }

        public void RemoveLike(Guid userId)
        {
            var like = _likes.FirstOrDefault(l => l.UserId == userId);
            if (like != null)
            {
                _likes.Remove(like);

                AddDomainEvent(new PostUnlikedEvent(Id, userId));
            }
        }
    }
}