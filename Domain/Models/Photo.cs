using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty; 
        public string ThumbnailUrl { get; set; } = string.Empty;
        [ForeignKey("Album")]
        public int AlbumId { get; set; }
        public Album? Album { get; set;}
    }
}
