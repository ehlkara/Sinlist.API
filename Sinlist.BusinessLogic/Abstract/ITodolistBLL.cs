using Sinlist.Shared.DTOs.Sinlists;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sinlist.BusinessLogic.Abstract
{
    public interface ITodolistBLL
    {
        Task<TodoListDto> AddTodoList(TodoListDto todoList);
        Task<TodoListDto> UpdateTodoList(TodoListDto todoList);
        Task<bool> DeleteTodolist(int todoListId);
        Task<TodoListDto> GetTodoListById(int todoListId);
        Task<List<TodoListDto>> GetTodoLists(string deviceInfo);

        Task<TodoListItemDto> AddTodolistItem(TodoListItemDto todoListItem);
        Task<TodoListItemDto> UpdateTodoListItem(TodoListItemDto todoListItem);
        Task<bool> DeleteTodoListItem(int todoListItemId);
        Task<List<TodoListItemDto>> GetTodoListItemsById(int todoListId);
    }
}
