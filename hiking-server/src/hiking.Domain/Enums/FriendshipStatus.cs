namespace Hiking.Domain.Enums;


public enum FriendshipStatus
{
    Pending,   // Demande envoyée, en attente de réponse
    Accepted,  // Demande acceptée, amis
    Rejected,  // Demande rejetée
    Removed    // Amitié supprimée
}