using System;
using Microsoft.EntityFrameworkCore;
using Sinlist.Core.Context;
using Sinlist.DataAccess.Abstract;
using Sinlist.Models.Entities.Sinlist;

namespace Sinlist.DataAccess.Concrete
{
    public class TodoListDAL : ITodoListDAL
    {

        private readonly SinlistDbContext _context;

        private readonly ITodoListItemDAL _dAL;

        public TodoListDAL(SinlistDbContext context, ITodoListItemDAL dAL)
        {
            _context = context;
            _dAL = dAL;
        }

        public async Task<int> AddTodoList(TodoList todoList)
        {
            await _context.TodoLists.AddAsync(todoList);
            await _context.SaveChangesAsync();
            return todoList.Id;
        }

        public async Task<bool> DeleteTodolist(int todoListId)
        {
            var todoListItems = await _dAL.GetTodoListItemsById(todoListId);
            foreach (var item in todoListItems)
            {
                item.IsDelete = true;
                item.IsActive = false;
                item.DeletedTime = DateTime.Now;

                await _dAL.UpdateTodoListItem(item);
            }
            var todoListResult = await _context.TodoLists.FindAsync(todoListId);
            todoListResult.IsDelete = true;
            todoListResult.IsActive = false;
            todoListResult.DeletedTime = DateTime.Now;
            _context.TodoLists.Update(todoListResult);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<TodoList> GetTodoListById(int todoListId)
        {
            var todolist = await _context.TodoLists.FirstOrDefaultAsync(x => x.Id == todoListId && x.IsDelete != true);
            return todolist;
        }

        public async Task<List<TodoList>> GetTodoLists(string deviceInfo)
        {
            var todolist = await _context.TodoLists.Where(x => x.DeviceInfo == deviceInfo && x.IsDelete != true).ToListAsync();
            return todolist;
        }

        public async Task<bool> UpdateTodoList(TodoList todoList)
        {
            var todoListResult = await _context.TodoLists.FindAsync(todoList.Id);

            todoListResult.Name = todoList.Name;

            _context.TodoLists.Update(todoList);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

