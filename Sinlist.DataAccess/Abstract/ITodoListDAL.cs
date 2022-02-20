using Sinlist.Models.Entities.Sinlist;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sinlist.DataAccess.Abstract
{
    public interface ITodoListDAL
    {
        // TODOLİST
        Task<TodoList> AddTodoList(TodoList todoList);
        Task<TodoList> UpdateTodoList(TodoList todoList);
        Task<bool> DeleteTodolist(TodoList todoList);
        Task<TodoList> GetTodoListById(int todoListId);
        Task<List<TodoList>> GetTodoLists(string deviceInfo);

        // TODOITEM
        Task<TodoListItem> AddTodolistItem(TodoListItem todoListItem);
        Task<TodoListItem> UpdateTodoListItem(TodoListItem todoListItem);
        Task<bool> DeleteTodoListItem(TodoListItem todoListItem);
        Task<List<TodoListItem>> GetTodoListItemsById(int todoListId);
        Task<TodoListItem> GetTodoListItemById(int todolistItemId);
    }
}
