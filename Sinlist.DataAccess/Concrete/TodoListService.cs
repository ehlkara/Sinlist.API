using Abp.UI;
using Microsoft.EntityFrameworkCore;
using Sinlist.Core.Context;
using Sinlist.DataAccess.Abstract;
using Sinlist.Models.Entities.Sinlist;
using Sinlist.Models.Errors;
using System;
using System.Threading.Tasks;

namespace Sinlist.DataAccess.Concrete
{
    public class TodoListService : ITodoListService
    {
        protected readonly SinlistDbContext _context;

        public TodoListService(SinlistDbContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<TodoList> AddTodoList(TodoList todoList)
        {
            try
            {
                await _context.TodoLists.AddAsync(todoList);
                await _context.SaveChangesAsync();

                return todoList;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException((int)ErrorCodes.TodoNotFound, ErrorMessages.TodoNotFound, ex.Message);
            }
        }

        public async Task<TodoListItem> AddTodolistItem(TodoListItem todoListItem)
        {
            try
            {
                await _context.TodoListItems.AddAsync(todoListItem);
                await _context.SaveChangesAsync();

                return todoListItem;
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException((int)ErrorCodes.TodosNotFound, ErrorMessages.TodosNotFound, ex.Message);
            }
        }

        public async Task<bool> DeleteTodolist(TodoList todoList)
        {
            try
            {
                var todoListResult = await _context.TodoLists.FindAsync(todoList.Id);
                _context.TodoLists.Remove(todoListResult);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException((int)ErrorCodes.TodoNotFound, ErrorMessages.TodoNotFound, ex.Message);
            }
        }

        public async Task<bool> DeleteTodoListItem(TodoListItem todoListItem)
        {
            try
            {
                var todoListItemResult = await _context.TodoListItems.FindAsync(todoListItem.Id);
                todoListItemResult.IsDelete = todoListItem.IsDelete = true;
                todoListItemResult.DeletedTime = todoListItem.DeletedTime = DateTime.Now;
                _context.TodoListItems.Update(todoListItemResult);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException((int)ErrorCodes.TodoNotFound, ErrorMessages.TodoNotFound, ex.Message);
            }
        }

        public async Task<TodoList> UpdateTodoList(TodoList todoList)
        {
            try
            {
                var todoListResult = await _context.TodoLists.FindAsync(todoList.Id);

                todoListResult.Name = todoList.Name;

                _context.TodoLists.Update(todoList);
                await _context.SaveChangesAsync();
                return todoListResult;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException((int)ErrorCodes.TodoNotFound, ErrorMessages.TodoNotFound, ex.Message);
            }
        }

        public async Task<TodoListItem> UpdateTodoListItem(TodoListItem todoListItem)
        {
            try
            {
                var todoListItemResult = await _context.TodoListItems.FindAsync(todoListItem.Id);

                todoListItemResult.Name = todoListItem.Name;
                todoListItemResult.Description = todoListItem.Description;
                todoListItemResult.Count = todoListItem.Count;

                _context.TodoListItems.Update(todoListItem);
                await _context.SaveChangesAsync();
                return todoListItemResult;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException((int)ErrorCodes.TodoNotFound, ErrorMessages.TodoNotFound, ex.Message);
            }
        }
    }
}
