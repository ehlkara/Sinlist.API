using System;
using Abp.UI;
using AutoMapper;
using Sinlist.BusinessLogic.Abstract;
using Sinlist.DataAccess.Abstract;
using Sinlist.DataAccess.Concrete;
using Sinlist.Models.Entities.Sinlist;
using Sinlist.Models.Errors;
using Sinlist.Shared.DTOs.Sinlists;

namespace Sinlist.BusinessLogic.SinlistService
{
	public class TodoListItemService : ITodoListItemBLL
	{
        private readonly ITodoListItemDAL _dal;
        private readonly IMapper _mapper;

        public TodoListItemService(ITodoListItemDAL dal, IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }

        public async Task<int> AddTodolistItem(TodoListItemDto todoListItem)
        {
            try
            {
                var mappedTodoListItem = _mapper.Map<TodoListItem>(todoListItem);
                var todoResult = await _dal.AddTodolistItem(mappedTodoListItem);

                return todoResult;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException((int)ErrorCodes.TodoItemNotCreate, ErrorMessages.TodoItemNotCreate, ex.Message);
            }
        }

        public async Task<bool> DeleteTodoListItem(int todoListItemId)
        {
            try
            {
                var todolistItem = await _dal.GetTodoListItemById(todoListItemId);
                var mappedTodolistItem = _mapper.Map<TodoListItem>(todolistItem);
                await _dal.DeleteTodoListItem(mappedTodolistItem);
                return true;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException((int)ErrorCodes.TodosNotFound, ErrorMessages.TodosNotFound, ex.Message);
            }
        }

        public async Task<TodoListItemDto> GetTodoListItemById(int todolistItemId)
        {
            try
            {
                var todolistItem = await _dal.GetTodoListItemById(todolistItemId);
                return _mapper.Map<TodoListItemDto>(todolistItem);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException((int)ErrorCodes.TodosNotFound, ErrorMessages.TodosNotFound, ex.Message);
            }
        }

        public async Task<List<TodoListItemDto>> GetTodoListItemsById(int todoListId)
        {
            try
            {
                var todolistItems = await _dal.GetTodoListItemsById(todoListId);
                return _mapper.Map<List<TodoListItemDto>>(todolistItems);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException((int)ErrorCodes.TodosNotFound, ErrorMessages.TodosNotFound, ex.Message);
            }
        }

        public async Task<bool> UpdateTodoListItem(TodoListItemDto todoListItem)
        {
            try
            {
                var mappedTodoItem = _mapper.Map<TodoListItem>(todoListItem);
                var todoItemResult = await _dal.UpdateTodoListItem(mappedTodoItem);

                return true;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException((int)ErrorCodes.TodoItemNotUpdate, ErrorMessages.TodoItemNotUpdate, ex.Message);
            }
        }
    }
}

