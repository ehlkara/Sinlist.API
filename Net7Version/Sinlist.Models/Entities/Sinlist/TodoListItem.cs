using System;
using System.ComponentModel.DataAnnotations.Schema;
using Sinlist.Models.Entities.Core;

namespace Sinlist.Models.Entities.Sinlist
{
	[Table("TodoListItem")]
	public class TodoListItem : BaseEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Count { get; set; }
		[ForeignKey("TodoListId")]
		public int TodoListId { get; set; }
		public TodoList TodoList { get; set; }
	}
}

