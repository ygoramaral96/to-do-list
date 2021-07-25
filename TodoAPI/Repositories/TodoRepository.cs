using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private DbSession _db;
        public TodoRepository(DbSession dbSession)
        {
            _db = dbSession;
        }

        public async Task<List<TodoItem>> GetTodoItemsAsync()
        {
            using (var conn = _db.Connection)
            {
                string query = "SELECT * FROM TodoItems";
                List<TodoItem> todoItems = (await conn.QueryAsync<TodoItem>(sql: query)).ToList();
                return todoItems;
            }
        }

        Task<TodoItem> ITodoRepository.CreateAsync(TodoItem newTodoItem)
        {
            throw new System.NotImplementedException();
        }

        Task<TodoItem> ITodoRepository.DeleteByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<TodoItem> ITodoRepository.GeCountAsync()
        {
            throw new System.NotImplementedException();
        }

        Task<TodoItem> ITodoRepository.GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<TodoItem> ITodoRepository.UpdateAsync(TodoItem todoItem)
        {
            throw new System.NotImplementedException();
        }
    }
}
