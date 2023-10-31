
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Requests.Album
{
    public class AlbumRequest
    {
        public string Title { get; set; } = string.Empty;        
        public int UserId { get; set; }        
    }
}
