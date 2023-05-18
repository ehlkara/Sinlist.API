using System;
using Microsoft.EntityFrameworkCore;
using Sinlist.Core.Context;
using Sinlist.DataAccess.Abstract;
using Sinlist.Models.Entities.Sinlist;

namespace Sinlist.DataAccess.Concrete
{
	public class TodoListItemDAL : ITodoListItemDAL
	{
        private readonly SinlistDbContext _context;

        public TodoListItemDAL(SinlistDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddTodolistItem(TodoListItem todoListItem)
        {
            var todolistResult = await _context.TodoLists.FirstOrDefaultAsync(x => x.Id == todoListItem.TodoListId);

            todolistResult.Id = todoListItem.Id;

            await _context.TodoListItems.AddAsync(todoListItem);
            await _context.SaveChangesAsync();

            return todoListItem.Id;
        }

        public async Task<bool> DeleteTodoListItem(TodoListItem todoListItem)
        {
            var todolistItemResult = await _context.TodoListItems.Where(x => x.TodoListId == todoListItem.TodoListId && x.Id == todoListItem.Id).FirstOrDefaultAsync();

            todolistItemResult.IsActive = false;
            todolistItemResult.IsDelete = true;
            todolistItemResult.DeletedTime = DateTime.Now;

            _context.TodoListItems.Update(todolistItemResult);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<TodoListItem> GetTodoListItemById(int todolistItemId)
        {
            var todolistItem = await _context.TodoListItems.FirstOrDefaultAsync(x => x.Id == todolistItemId && x.IsDelete != true);
            return todolistItem;
        }

        public async Task<List<TodoListItem>> GetTodoListItemsById(int todoListId)
        {
            var todoListItems = await _context.TodoListItems.Where(x => x.IsDelete != true && x.TodoListId == todoListId).ToListAsync();
            return todoListItems;
        }

        public async Task<bool> UpdateTodoListItem(TodoListItem todoListItem)
        {
            var todoListItemResult = await _context.TodoListItems.FindAsync(todoListItem.Id);

            todoListItemResult.Name = todoListItem.Name;
            todoListItemResult.Description = todoListItem.Description;
            todoListItemResult.Count = todoListItem.Count;
            todoListItemResult.IsDelete = todoListItem.IsDelete;
            todoListItemResult.IsActive = todoListItem.IsActive;
            todoListItemResult.DeletedTime = todoListItem.DeletedTime;
            todoListItemResult.UpdatedTime = todoListItem.UpdatedTime;

            _context.TodoListItems.Update(todoListItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

