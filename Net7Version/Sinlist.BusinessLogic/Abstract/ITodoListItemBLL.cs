using System;
using Sinlist.Models.Entities.Sinlist;
using Sinlist.Shared.DTOs.Sinlists;

namespace Sinlist.BusinessLogic.Abstract
{
	public interface ITodoListItemBLL
	{
        Task<int> AddTodolistItem(TodoListItemDto todoListItem);
        Task<bool> UpdateTodoListItem(TodoListItemDto todoListItem);
        Task<bool> DeleteTodoListItem(int todoListItemId);
        Task<List<TodoListItemDto>> GetTodoListItemsById(int todoListId);
        Task<TodoListItemDto> GetTodoListItemById(int todolistItemId);
    }
}

