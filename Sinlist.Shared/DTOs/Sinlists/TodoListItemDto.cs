using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinlist.Shared.DTOs.Sinlists
{
    public class  TodoListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public TodoListDto TodoList { get; set; }
    }
}
