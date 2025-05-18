using Hiking.Domain.Common;
using Hiking.Domain.Events;
using Hiking.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Hiking.Domain.Entities
{
    /// <summary>
    /// Représente un utilisateur dans le système
    /// </summary>
    public class User : AggregateRoot
    {
        // Propriétés
        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string DisplayName { get; private set; }
        public string? ProfilePictureUrl { get; private set; }
        public string? Bio { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime LastActive { get; private set; }
        public UserStatus Status { get; private set; }

        // Relations
        private readonly List<Post> _posts = new();
        public IReadOnlyCollection<Post> Posts => _posts.AsReadOnly();

        private readonly List<Comment> _comments = new();
        public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

        private readonly List<Friendship> _friendships = new();
        public IReadOnlyCollection<Friendship> Friendships => _friendships.AsReadOnly();

        // Constructeur privé pour EF Core
        // Constructeur privé pour EF Core
        private User()
        {
            Username = string.Empty;
            Email = string.Empty;
            DisplayName = string.Empty;
            CreatedAt = DateTime.UtcNow;
            LastActive = DateTime.UtcNow;
            Status = UserStatus.Offline;
        }

        // Constructeur principal
        public User(Guid id, string username, string email, string displayName)
        {
            Id = id;
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            DisplayName = displayName ?? throw new ArgumentNullException(nameof(displayName));
            CreatedAt = DateTime.UtcNow;
            LastActive = DateTime.UtcNow;
            Status = UserStatus.Offline;

            AddDomainEvent(new UserCreatedEvent(id));
        }

        // Méthodes de domaine
        public void UpdateProfile(string displayName, string bio, string profilePictureUrl)
        {
            DisplayName = displayName ?? DisplayName;
            Bio = bio ?? Bio;
            ProfilePictureUrl = profilePictureUrl ?? ProfilePictureUrl;

            AddDomainEvent(new UserProfileUpdatedEvent(Id));
        }

        public void UpdateStatus(UserStatus status)
        {
            Status = status;
            LastActive = DateTime.UtcNow;

            AddDomainEvent(new UserStatusChangedEvent(Id, status));
        }

        public void AddPost(Post post)
        {
            _posts.Add(post);
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public void AddFriendship(Friendship friendship)
        {
            _friendships.Add(friendship);
        }
    }
}