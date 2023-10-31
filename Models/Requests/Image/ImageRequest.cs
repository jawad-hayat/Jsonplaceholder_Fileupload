

namespace Models.Requests.Image
{
    public class ImageRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string ThumbnailUrl { get; set; } = string.Empty;
        public int AlbumId { get; set; }
    }
}
