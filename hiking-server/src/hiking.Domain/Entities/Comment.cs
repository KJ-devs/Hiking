using Hiking.Domain.Common;
using Hiking.Domain.Events;
using System;

namespace Hiking.Domain.Entities
{
    /// <summary>
    /// Représente un commentaire sur une publication
    /// </summary>
    public class Comment : Entity
    {
        // Propriétés
        public Guid Id { get; private set; }
        public Guid PostId { get; private set; }
        public Guid AuthorId { get; private set; }
        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ModifiedAt { get; private set; }
        public bool IsEdited => ModifiedAt.HasValue;

        // Navigation properties
        public Post Post { get; private set; }
        public User Author { get; private set; }

        // Constructeur privé pour EF Core
        private Comment() { }

        // Constructeur principal
        public Comment(Guid id, Guid postId, Guid authorId, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Le contenu du commentaire ne peut pas être vide", nameof(content));

            Id = id;
            PostId = postId;
            AuthorId = authorId;
            Content = content;
            CreatedAt = DateTime.UtcNow;
        }

        // Méthodes de domaine
        public void Update(string newContent)
        {
            if (string.IsNullOrWhiteSpace(newContent))
                throw new ArgumentException("Le contenu du commentaire ne peut pas être vide", nameof(newContent));

            Content = newContent;
            ModifiedAt = DateTime.UtcNow;
        }
    }
}