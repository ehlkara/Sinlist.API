using Sinlist.Models.Entities.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sinlist.Models.Entities.Sinlist
{
    [Table("TodoList")]
    public class TodoList : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
