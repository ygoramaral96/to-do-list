using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    interface ITodoRepository
    {
        Task<List<TodoItem>> GetTodoItemsAsync();
    }
}
