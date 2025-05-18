
/// <summary>
/// Représente un élément média (image, vidéo, lien)
/// </summary>
namespace Hiking.Domain.Entities
{
    public class MediaItem
    {
        public string Url { get; }
        public MediaType Type { get; }
        public string? ThumbnailUrl { get; }

        // Constructeur privé pour EF Core
        private MediaItem() { }

        public MediaItem(string url, MediaType type, string? thumbnailUrl = null)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("L'URL du média ne peut pas être vide", nameof(url));

            Url = url;
            Type = type;
            ThumbnailUrl = thumbnailUrl;
        }
    }
}
