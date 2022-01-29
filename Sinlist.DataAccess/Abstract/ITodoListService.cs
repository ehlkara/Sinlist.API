using Sinlist.Models.Entities.Sinlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinlist.DataAccess.Abstract
{
    public interface ITodoListService
    {
        Task<TodoList> AddTodoList(TodoList todoList);
        Task<TodoList> UpdateTodoList(TodoList todoList);
        Task<bool> DeleteTodolist(TodoList todoList);

        Task<TodoListItem> AddTodolistItem(TodoListItem todoListItem);
        Task<TodoListItem> UpdateTodoListItem(TodoListItem todoListItem);
        Task<bool> DeleteTodoListItem(TodoListItem todoListItem);
    }
}
