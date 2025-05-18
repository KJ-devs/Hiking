using System;
using System.Collections.Generic;
using Hiking.Domain.Entities;

namespace Hiking.Domain.ValueObjects
{
    /// <summary>
    /// Objet de valeur représentant le contenu d'une publication
    /// </summary>
    public class PostContent
    {
        public string? Text { get; }
        public PostContentType Type { get; }
        public IReadOnlyList<MediaItem> MediaItems => _mediaItems.AsReadOnly();

        private readonly List<MediaItem> _mediaItems = new();

        // Constructeur privé pour EF Core
        private PostContent() { }

        // Constructeur pour contenu de type texte
        public PostContent(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Le texte ne peut pas être vide pour une publication de type texte", nameof(text));

            Text = text;
            Type = PostContentType.Text;
        }

        // Constructeur pour contenu avec média
        public PostContent(string text, List<MediaItem> mediaItems, PostContentType type)
        {
            if (type != PostContentType.Text && (mediaItems == null || mediaItems.Count == 0))
                throw new ArgumentException("Des médias sont requis pour ce type de publication", nameof(mediaItems));

            Text = text;
            Type = type;

            if (mediaItems != null)
            {
                _mediaItems.AddRange(mediaItems);
            }
        }

        // Factory methods
        public static PostContent CreateTextContent(string text)
        {
            return new PostContent(text);
        }

        public static PostContent CreateImageContent(string text, List<MediaItem> images)
        {
            foreach (var image in images)
            {
                if (image.Type != MediaType.Image)
                    throw new ArgumentException("Tous les éléments doivent être des images", nameof(images));
            }

            return new PostContent(text, images, PostContentType.Image);
        }

        public static PostContent CreateVideoContent(string text, MediaItem video)
        {
            if (video.Type != MediaType.Video)
                throw new ArgumentException("L'élément doit être une vidéo", nameof(video));

            return new PostContent(text, new List<MediaItem> { video }, PostContentType.Video);
        }

        public static PostContent CreateLinkContent(string text, string url)
        {
            var linkMedia = new MediaItem(url, MediaType.Link);
            return new PostContent(text, new List<MediaItem> { linkMedia }, PostContentType.Link);
        }
    }
   
}