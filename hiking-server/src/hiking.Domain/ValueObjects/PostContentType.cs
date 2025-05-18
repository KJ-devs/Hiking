/// <summary>
/// Type de contenu d'une publication
/// </summary>
namespace Hiking.Domain.ValueObjects
{
    public enum PostContentType
    {
        Text,      // Texte uniquement
        Image,     // Image avec texte optionnel
        Video,     // Vidéo avec texte optionnel
        Link       // Lien avec texte optionnel
    }
}