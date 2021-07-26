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

        public async Task<TodoItem> CreateAsync(TodoItem newTodoItem)
        {
            using (var conn = _db.Connection)
            {
                string query = @"
                    INSERT INTO TodoItems(Title, Completed, Order) 
                    OUTPUT INSERTED.*
                    VALUES (@Title, @Completed, @Order)";

                var todoItem = await conn.QuerySingleAsync<TodoItem>(sql: query, param: newTodoItem);
                return todoItem;
            }
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            using (var conn = _db.Connection)
            {
                string query = "DELETE FROM TodoItems WHERE Id = @id";
                var result = await conn.ExecuteAsync(sql: query, param: new { id });
                return result;
            }
        }

        public async Task<int> GeCountAsync()
        {
            using (var conn = _db.Connection)
            {
                string query = "SELECT COUNT(*) FROM TodoItems";
                int qtyTodoItems = await conn.ExecuteScalarAsync<int>(sql: query);
                return qtyTodoItems;
            }
        }

        public async Task<TodoItem> GetByIdAsync(int id)
        {
            using (var conn = _db.Connection)
            {
                string query = "SELECT * FROM TodoItems WHERE Id = @id";
                TodoItem todoItem = await conn.QueryFirstOrDefaultAsync<TodoItem>
                    (sql: query, param: new { id });
                return todoItem;
            }
        }

        public async Task<int> UpdateAsync(TodoItem todoItem)
        {
            using (var conn = _db.Connection)
            {
                string query = @"UPDATE TodoItems 
                    SET (Title = @Title, Completed = @Completed, Order = @Order)  
                    WHERE Id = @id";
                var result = await conn.ExecuteAsync(sql: query, param: todoItem);
                return result;
            }
        }
    }
}
