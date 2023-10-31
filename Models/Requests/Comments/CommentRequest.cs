
namespace Models.Requests.Comments
{
    public class CommentRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;        
        public int PostId { get; set; }
    }
}
