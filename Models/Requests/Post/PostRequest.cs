
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Requests.Post
{
    public class PostRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
