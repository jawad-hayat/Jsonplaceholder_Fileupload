using Domain.Models;
using Models.Requests.Todo;
using Models.Response;

namespace Business.Interfaces
{
    public interface ITodoService
    {
        //public Task<User> GetLoggedUserInfo();

        public string GetLoggedInUserId();

        public Task<ApiResponse> CreateTodo(TodoRequest request);
        public ApiResponse EditTodo(TodoRequest request, int id);
        public Todo GetTodoById(int id);
        public IEnumerable<Todo> GetTodos();
        public bool DeleteTodo(int id);
    }
}
