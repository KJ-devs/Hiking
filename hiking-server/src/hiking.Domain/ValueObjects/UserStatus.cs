/// <summary>
/// Statut de connexion d'un utilisateur
/// </summary>
namespace Hiking.Domain.ValueObjects
{
    public enum UserStatus
    {
        Online,    // Utilisateur en ligne
        Offline,   // Utilisateur hors ligne
        Away,      // Utilisateur absent
        Busy       // Utilisateur occupé
    }
}