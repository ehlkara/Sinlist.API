using System;
using Sinlist.Models.Entities.Sinlist;
using Sinlist.Shared.DTOs.Sinlists;

namespace Sinlist.BusinessLogic.Abstract
{
	public interface ITodoListBLL
	{
        Task<int> AddTodoList(TodoListDto todoList);
        Task<bool> UpdateTodoList(TodoListDto todoList);
        Task<bool> DeleteTodolist(int todoListId);
        Task<TodoListDto> GetTodoListById(int todoListId);
        Task<List<TodoListDto>> GetTodoLists(string deviceInfo);
    }
}

