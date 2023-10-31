

namespace Models.Requests.Todo
{
    public class TodoRequest
    {
        public string Title { get; set; } = string.Empty;
        public bool Completed { get; set; }
        public int UserId { get; set; }
    }
}
