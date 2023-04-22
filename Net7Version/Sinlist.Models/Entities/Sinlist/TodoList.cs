using System;
using System.ComponentModel.DataAnnotations.Schema;
using Sinlist.Models.Entities.Core;

namespace Sinlist.Models.Entities.Sinlist
{
	[Table("TodoList")]
	public class TodoList : BaseEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string DeviceInfo { get; set; }
		public List<TodoListItem> TodoListItems { get; set; }
	}
}

