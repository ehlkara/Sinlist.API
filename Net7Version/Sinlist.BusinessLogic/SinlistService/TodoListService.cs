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
	public class TodoListService : ITodoListBLL
	{
        private readonly ITodoListDAL _dAL;
        private readonly IMapper _mapper;

        public TodoListService(ITodoListDAL dAL, IMapper mapper)
        {
            _dAL = dAL;
            _mapper = mapper;
        }

        public async Task<int> AddTodoList(TodoListDto todoList)
        {
            try
            {
                var mappedDto = _mapper.Map<TodoList>(todoList);
                var todolistResult = await _dAL.AddTodoList(mappedDto);
                return todolistResult;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException((int)ErrorCodes.TodoNotCreate, ErrorMessages.TodoNotCreate, ex.Message);
            }
        }

        public async Task<bool> DeleteTodolist(int todoListId)
        {
            try
            {
                var todolist = await _dAL.GetTodoListById(todoListId);
                return await _dAL.DeleteTodolist(todolist.Id);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException((int)ErrorCodes.TodoNotFound, ErrorMessages.TodoNotFound, ex.Message);
            }
        }

        public async Task<TodoListDto> GetTodoListById(int todoListId)
        {
            try
            {
                var todolist = await _dAL.GetTodoListById(todoListId);
                return _mapper.Map<TodoListDto>(todolist);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException((int)ErrorCodes.TodoNotFound, ErrorMessages.TodoNotFound, ex.Message);
            }
        }

        public async Task<List<TodoListDto>> GetTodoLists(string deviceInfo)
        {
            try
            {
                var todolist = await _dAL.GetTodoLists(deviceInfo);
                return _mapper.Map<List<TodoListDto>>(todolist);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException((int)ErrorCodes.TodosNotFound, ErrorMessages.TodosNotFound, ex.Message);
            }
        }

        public async Task<bool> UpdateTodoList(TodoListDto todoList)
        {
            try
            {
                var mappedTodo = _mapper.Map<TodoList>(todoList);
                var todoResult = await _dAL.UpdateTodoList(mappedTodo);

                return true;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException((int)ErrorCodes.TodoNotUpdate, ErrorMessages.TodoNotUpdate, ex.Message);
            }
        }
    }
}

