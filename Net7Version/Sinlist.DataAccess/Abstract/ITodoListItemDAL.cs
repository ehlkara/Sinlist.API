using System;
using Sinlist.Models.Entities.Sinlist;

namespace Sinlist.DataAccess.Abstract
{
	public interface ITodoListItemDAL
	{
        Task<int> AddTodolistItem(TodoListItem todoListItem);
        Task<bool> UpdateTodoListItem(TodoListItem todoListItem);
        Task<bool> DeleteTodoListItem(TodoListItem todoListItem);
        Task<List<TodoListItem>> GetTodoListItemsById(int todoListId);
        Task<TodoListItem> GetTodoListItemById(int todolistItemId);
    }
}

