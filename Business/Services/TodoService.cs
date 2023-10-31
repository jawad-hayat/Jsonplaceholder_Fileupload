using Business.Interfaces;
using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models.Requests.Todo;
using Models.Response;

namespace Business.Services
{
    public class TodoService : ITodoService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<Todo> _todoRepository;

        public TodoService(IHttpContextAccessor httpContextAccessor, IRepository<Todo> repository)
        {
            _httpContextAccessor = httpContextAccessor;
            _todoRepository = repository;
        }

        public async Task<ApiResponse> CreateTodo(TodoRequest request)
        {
            var newTodo = new Todo()
            {
                UserId = request.UserId,
                Title = request.Title,
                Completed = request.Completed,
            };

            var isCreated = _todoRepository.Add(newTodo);
            if (isCreated)
            {
                return new ApiResponse
                {
                    Success = true,
                    Message = "Todo Created Successfully!"
                };
            }
            return new ApiResponse
            {
                Success = false,
                Message = "unable to create Todo!"
            };
        }


        public ApiResponse EditTodo(TodoRequest request, int id)
        {
            var todo = _todoRepository.GetFirstorDefault(e => e.Id == id);
            if (todo == null)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = "provided todo id doesnot exist!"
                };
            }

            todo.Title = request.Title;
            todo.Completed = request.Completed;
            todo.UserId = request.UserId;

            var isUpdated = _todoRepository.Update(todo);
            if (isUpdated)
            {
                return new ApiResponse
                {
                    Success = true,
                    Message = "Todo Updated Successfully!"
                };
            }
            return new ApiResponse
            {
                Success = false,
                Message = "unable to Update Todo!"
            };
        }

        public bool DeleteTodo(int id)
        {
            var todo = _todoRepository.GetFirstorDefault(e => e.Id == id);
            if (todo == null) return false;
            var result = _todoRepository.Remove(todo);
            if (result == null) return false;
            return true;
        }

        public string GetLoggedInUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst("Id").Value;
        }

        public Todo GetTodoById(int id)
        {
            var result = _todoRepository.GetFirstorDefault(e => e.Id == id);
            return result;
        }

        public IEnumerable<Todo> GetTodos()
        {
            var result = _todoRepository.GetAll();
            return result;
        }

        //public async Task<User> GetLoggedUserInfo()
        //{
        //    if (_httpContextAccessor.HttpContext.User.Claims.Any())
        //    {
        //        var userId = _httpContextAccessor.HttpContext.User.FindFirst("Id").Value;
        //        return await _userManager.Users.Where(x => x.Id == int.Parse(userId)).FirstOrDefaultAsync();
        //    }
        //    return null;
        //}
    }
}
