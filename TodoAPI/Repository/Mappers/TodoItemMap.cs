using Dapper.FluentMap.Dommel.Mapping;
using TodoApi.Models;

namespace TodoApi.Repository.Mappers
{
    public class TodoItemMap : DommelEntityMap<TodoItem>
    {
        public TodoItemMap()
        {
            ToTable("todoitems");
            Map(x => x.Id).ToColumn("id").IsKey();
            Map(x => x.CreatedAt).ToColumn("createdat");
            Map(x => x.Title).ToColumn("title");
            Map(x => x.Completed).ToColumn("completed");
            Map(x => x.Order).ToColumn("order");
        }
    }
}
