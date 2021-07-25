using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public interface ITodoRepository
    {
        Task<List<TodoItem>> GetTodoItemsAsync();
        Task<TodoItem> GetByIdAsync(int id);
        Task<TodoItem> GeCountAsync();
        Task<TodoItem> CreateAsync(TodoItem newTodoItem);
        Task<TodoItem> UpdateAsync(TodoItem todoItem);
        Task<TodoItem> DeleteByIdAsync(int id);
    }
}
