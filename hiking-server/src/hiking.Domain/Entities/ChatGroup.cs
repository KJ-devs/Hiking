using Hiking.Domain.Common;
using Hiking.Domain.Entities;
using Hiking.Domain.Events.Chat;
namespace Hiking.Domain.Events
{

    /// <summary>
    /// Représente un groupe de chat
    /// </summary>
    public class ChatGroup : AggregateRoot
    {
        // Propriétés
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid CreatorId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string PictureUrl { get; private set; }

        // Navigation properties
        public User Creator { get; private set; }

        // Relations
        private readonly List<ChatGroupMember> _members = new();
        public IReadOnlyCollection<ChatGroupMember> Members => _members.AsReadOnly();

        private readonly List<ChatMessage> _messages = new();
        public IReadOnlyCollection<ChatMessage> Messages => _messages.AsReadOnly();

        // Constructeur privé pour EF Core
        private ChatGroup() { }

        // Constructeur principal
        public ChatGroup(Guid id, string name, Guid creatorId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Le nom du groupe ne peut pas être vide", nameof(name));

            Id = id;
            Name = name;
            CreatorId = creatorId;
            CreatedAt = DateTime.UtcNow;

            // Ajout automatique du créateur comme membre et admin
            AddMember(creatorId, isAdmin: true);

            AddDomainEvent(new ChatGroupCreatedEvent(id, creatorId));
        }

        // Méthodes de domaine
        public void UpdateDetails(string name, string pictureUrl)
        {
            if (!string.IsNullOrWhiteSpace(name))
                Name = name;

            PictureUrl = pictureUrl;

            AddDomainEvent(new ChatGroupUpdatedEvent(Id));
        }

        public void AddMember(Guid userId, bool isAdmin = false)
        {
            if (_members.Any(m => m.UserId == userId))
                return;

            var member = new ChatGroupMember(Id, userId, isAdmin);
            _members.Add(member);

            AddDomainEvent(new ChatGroupMemberAddedEvent(Id, userId));
        }

        public void RemoveMember(Guid userId)
        {
            var member = _members.FirstOrDefault(m => m.UserId == userId);
            if (member != null)
            {
                _members.Remove(member);

                AddDomainEvent(new ChatGroupMemberRemovedEvent(Id, userId));

                // Si le groupe n'a plus de membres, on pourrait le supprimer
                if (!_members.Any())
                {
                    AddDomainEvent(new ChatGroupEmptyEvent(Id));
                }
            }
        }

        public void PromoteToAdmin(Guid userId)
        {
            var member = _members.FirstOrDefault(m => m.UserId == userId);
            if (member != null && !member.IsAdmin)
            {
                member.PromoteToAdmin();

                AddDomainEvent(new ChatGroupAdminPromotedEvent(Id, userId));
            }
        }

        public void DemoteFromAdmin(Guid userId)
        {
            // Ne jamais dégrader le créateur
            if (userId == CreatorId)
                return;

            var member = _members.FirstOrDefault(m => m.UserId == userId && m.IsAdmin);
            if (member != null)
            {
                member.DemoteFromAdmin();

                AddDomainEvent(new ChatGroupAdminDemotedEvent(Id, userId));
            }
        }

        public void AddMessage(ChatMessage message)
        {
            if (message.ChatGroupId != Id)
                throw new ArgumentException("Le message n'appartient pas à ce groupe");

            _messages.Add(message);
        }

        public bool IsMember(Guid userId) => _members.Any(m => m.UserId == userId);

        public bool IsAdmin(Guid userId) => _members.Any(m => m.UserId == userId && m.IsAdmin);
    }

    /// <summary>
    /// Représente un membre d'un groupe de chat
    /// </summary>
    public class ChatGroupMember : Entity
    {
        // Propriétés
        public Guid ChatGroupId { get; private set; }
        public Guid UserId { get; private set; }
        public bool IsAdmin { get; private set; }
        public DateTime JoinedAt { get; private set; }

        // Navigation properties
        public ChatGroup ChatGroup { get; private set; }
        public User User { get; private set; }

        // Constructeur privé pour EF Core
        private ChatGroupMember() { }

        // Constructeur principal
        public ChatGroupMember(Guid chatGroupId, Guid userId, bool isAdmin)
        {
            ChatGroupId = chatGroupId;
            UserId = userId;
            IsAdmin = isAdmin;
            JoinedAt = DateTime.UtcNow;
        }

        // Méthodes de domaine
        public void PromoteToAdmin()
        {
            IsAdmin = true;
        }

        public void DemoteFromAdmin()
        {
            IsAdmin = false;
        }
    }
}