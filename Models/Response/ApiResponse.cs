
namespace Models.Response
{
    public class ApiResponse
    {
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public string RefreshToken { get; set; }
        public List<string> Errors { get; set; }
    }
}
