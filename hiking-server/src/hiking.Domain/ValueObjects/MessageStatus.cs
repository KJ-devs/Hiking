/// <summary>
/// Statut d'un message
/// </summary>
namespace Hiking.Domain.ValueObjects
{
    public enum MessageStatus
    {
        Sent,      // Message envoyé
        Delivered, // Message livré
        Read       // Message lu
    }
}