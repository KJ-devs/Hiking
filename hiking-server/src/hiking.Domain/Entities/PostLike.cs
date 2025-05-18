using Hiking.Domain.Common;
using Hiking.Domain.Events;
using Hiking.Domain.ValueObjects;
using System;
using System.Collections.Generic;
namespace Hiking.Domain.Entities
{
    public class PostLike : Entity
    {
        // Propriétés
        public Guid PostId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Post? Post { get; private set; }
        public User? User { get; private set; }

        private PostLike() { }

        public PostLike(Guid postId, Guid userId)
        {
            PostId = postId;
            UserId = userId;
            CreatedAt = DateTime.UtcNow;
        }
    }
}