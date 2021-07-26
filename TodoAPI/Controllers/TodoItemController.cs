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

        [HttpPost]
        public async Task<IActionResult> create(TodoItem newTodoItem)
        {
            var result = await _todoRepository.CreateAsync(newTodoItem);
            return Ok(result);
        }

        [HttpGet]
        [Route("count")]
        public async Task<IActionResult> count()
        {
            var result = await _todoRepository.GeCountAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> list()
        {
            var result = await _todoRepository.GetTodoItemsAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> findById(int id)
        {
            var result = await _todoRepository.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> update(TodoItem todoItem)
        {
            var result = await _todoRepository.UpdateAsync(todoItem);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> deleteById(int id)
        {
            var result = await _todoRepository.DeleteByIdAsync(id);
            return Ok(result);
        }
    }
}
