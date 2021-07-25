using TodoApi.Models;
using TodoApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoItemController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        [Route("todos")]
        public async Task<IActionResult> GetTodoAsync()
        {
            var result = await _todoRepository.GetTodoItemsAsync();
            return Ok(result);
        }

    }
}
