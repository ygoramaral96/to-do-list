using System;

namespace TodoApi.Models
{
    public class TodoItem : BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
        public int? Order { get; set; }

    }
}
