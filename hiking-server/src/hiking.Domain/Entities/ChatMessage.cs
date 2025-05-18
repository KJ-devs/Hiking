
using Hiking.Domain.Common;
using Hiking.Domain.Events;
using Hiking.Domain.Events.Chat.Message;
using Hiking.Domain.ValueObjects;
namespace Hiking.Domain.Entities
{
    /// <summary>
    /// Représente un message de chat entre utilisateurs
    /// </summary>
    public class ChatMessage : Entity
    {
        // Propriétés
        public Guid Id { get; private set; }
        public Guid SenderId { get; private set; }
        public Guid? RecipientId { get; private set; }  // Null si message de groupe
        public Guid? ChatGroupId { get; private set; }  // Null si message privé
        public string Content { get; private set; }
        public DateTime SentAt { get; private set; }
        public MessageStatus Status { get; private set; }

        // Navigation properties
        public User Sender { get; private set; }
        public User Recipient { get; private set; }
        public ChatGroup ChatGroup { get; private set; }

        private readonly List<MessageReadReceipt> _readReceipts = new();
        public IReadOnlyCollection<MessageReadReceipt> ReadReceipts => _readReceipts.AsReadOnly();

        // Constructeur privé pour EF Core
        private ChatMessage() { }

        // Constructeur pour message privé
        public ChatMessage(Guid id, Guid senderId, Guid recipientId, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Le contenu du message ne peut pas être vide", nameof(content));

            Id = id;
            SenderId = senderId;
            RecipientId = recipientId;
            Content = content;
            SentAt = DateTime.UtcNow;
            Status = MessageStatus.Sent;

            AddDomainEvent(new PrivateMessageSentEvent(id, senderId, recipientId));
        }

        // Constructeur pour message de groupe
        public ChatMessage(Guid id, Guid senderId, Guid chatGroupId, string content, bool isGroupMessage)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Le contenu du message ne peut pas être vide", nameof(content));

            Id = id;
            SenderId = senderId;
            ChatGroupId = chatGroupId;
            Content = content;
            SentAt = DateTime.UtcNow;
            Status = MessageStatus.Sent;

            AddDomainEvent(new GroupMessageSentEvent(id, senderId, chatGroupId));
        }

        // Méthodes de domaine
        public void MarkAsDelivered()
        {
            if (Status == MessageStatus.Sent)
            {
                Status = MessageStatus.Delivered;
                AddDomainEvent(new MessageDeliveredEvent(Id));
            }
        }

        public void AddReadReceipt(Guid userId)
        {
            if (!_readReceipts.Any(r => r.UserId == userId))
            {
                var receipt = new MessageReadReceipt(Id, userId);
                _readReceipts.Add(receipt);

                AddDomainEvent(new MessageReadEvent(Id, userId));
            }
        }

        public bool IsReadBy(Guid userId) => _readReceipts.Any(r => r.UserId == userId);
    }

    /// <summary>
    /// Représente un accusé de lecture pour un message
    /// </summary>
    public class MessageReadReceipt : Entity
    {
        // Propriétés
        public Guid MessageId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime ReadAt { get; private set; }

        // Navigation properties
        public ChatMessage Message { get; private set; }
        public User User { get; private set; }

        // Constructeur privé pour EF Core
        private MessageReadReceipt() { }

        // Constructeur principal
        public MessageReadReceipt(Guid messageId, Guid userId)
        {
            MessageId = messageId;
            UserId = userId;
            ReadAt = DateTime.UtcNow;
        }
    }
}