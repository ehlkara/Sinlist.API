using System;
using Sinlist.Models.Entities.Sinlist;

namespace Sinlist.DataAccess.Abstract
{
	public interface ITodoListDAL
	{
        Task<int> AddTodoList(TodoList todoList);
        Task<bool> UpdateTodoList(TodoList todoList);
        Task<bool> DeleteTodolist(int todoListId);
        Task<TodoList> GetTodoListById(int todoListId);
        Task<List<TodoList>> GetTodoLists(string deviceInfo);
    }
}

