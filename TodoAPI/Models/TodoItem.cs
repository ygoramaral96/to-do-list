using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
        public int? Order { get; set; }

    }
}
