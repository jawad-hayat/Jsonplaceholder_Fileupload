using Business.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Requests.Todo;

namespace Assignment9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        [HttpPost("createtodo")]
        public async Task<IActionResult> CreateTodo(TodoRequest request)
        {
            request.UserId = int.Parse(_todoService.GetLoggedInUserId());
            if (ModelState.IsValid)
            {
                var result = _todoService.CreateTodo(request);                
                return Ok(result);
            }
            return BadRequest("provide todo details");
        }

        [HttpGet("gettodo")]
        public async Task<IActionResult> GetTodo([FromQuery] int id)
        {
            if (ModelState.IsValid)
            {
                var result = _todoService.GetTodoById(id);
                if(result != null) return Ok(result);
                return BadRequest("todo with "+ id+" id doesnot exist!");
            }
            return BadRequest("provide todo id!");
        }

        [HttpGet("gettodos")]
        public async Task<IActionResult> GetTodos()
        {
            var result = _todoService.GetTodos();
            if (result != null) return Ok(result);
            return Ok("no todos found ;)");
        }

        [HttpGet("deletetodo")]
        public async Task<IActionResult> DeleteTodo([FromQuery] int id)
        {
            if (ModelState.IsValid)
            {
                var result = _todoService.DeleteTodo(id);
                if (result)
                {
                    return Ok("Todo deleted successfully");
                }
                return BadRequest("provided todo id doesnot exist!");
            }
            return BadRequest("provide todo id!");
        }

        [HttpPost("edittodo")]
        public async Task<IActionResult> EditTodo([FromBody] TodoRequest request, int id)
        {
            request.UserId = int.Parse(_todoService.GetLoggedInUserId());
            if (ModelState.IsValid)
            {
                var result = _todoService.EditTodo(request, id);
                return Ok(result);
            }
            return BadRequest("provide todo details");
        }
    }
}
