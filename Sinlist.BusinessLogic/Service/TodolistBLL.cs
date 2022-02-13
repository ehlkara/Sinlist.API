using AutoMapper;
using Sinlist.BusinessLogic.Abstract;
using Sinlist.DataAccess.Abstract;
using Sinlist.Models.Entities.Sinlist;
using Sinlist.Shared.DTOs.Sinlists;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sinlist.BusinessLogic.Service
{
    public class TodolistBLL : ITodolistBLL
    {
        private readonly ITodoListDAL _todoListDAL;
        private readonly IMapper _mapper;

        public TodolistBLL(ITodoListDAL todoListDAL, IMapper mapper)
        {
            _todoListDAL = todoListDAL;
            _mapper = mapper;
        }

        public async Task<TodoListDto> AddTodoList(TodoListDto todoList)
        {
            var mappedTodo = _mapper.Map<TodoList>(todoList);
            var todoResult = await _todoListDAL.AddTodoList(mappedTodo);

            return _mapper.Map<TodoListDto>(todoResult);
        }

        public async Task<TodoListItemDto> AddTodolistItem(TodoListItemDto todoListItem)
        {
            var mappedTodoListItem = _mapper.Map<TodoListItem>(todoListItem);
            var todoResult = await _todoListDAL.AddTodolistItem(mappedTodoListItem);

            return _mapper.Map<TodoListItemDto>(todoResult);
        }

        public async Task<bool> DeleteTodolist(int todoListId)
        {
            var todolist = await _todoListDAL.GetTodoListById(todoListId);
            return await _todoListDAL.DeleteTodolist(todolist);
        }

        public async Task<bool> DeleteTodoListItem(int todoListItemId)
        {
            var todolistItems = await GetTodoListItemsById(todoListItemId);
            var mappedTodolistItem = _mapper.Map<TodoListItem>(todolistItems);
            return await _todoListDAL.DeleteTodoListItem(mappedTodolistItem);
        }

        public async Task<TodoListDto> GetTodoListById(int todoListId)
        {
            var todolist = await _todoListDAL.GetTodoListById(todoListId);
            return _mapper.Map<TodoListDto>(todolist);
        }

        public async Task<List<TodoListItemDto>> GetTodoListItemsById(int todoListId)
        {
            var todolistItems = await _todoListDAL.GetTodoListItemsById(todoListId);
            return _mapper.Map<List<TodoListItemDto>>(todolistItems);
        }

        public async Task<List<TodoListDto>> GetTodoLists(string deviceInfo)
        {
            var todolist = await _todoListDAL.GetTodoLists(deviceInfo);
            return _mapper.Map<List<TodoListDto>>(todolist);
        }

        public async Task<TodoListDto> UpdateTodoList(TodoListDto todoList)
        {
            var mappedTodo = _mapper.Map<TodoList>(todoList);
            var todoResult = await _todoListDAL.UpdateTodoList(mappedTodo);

            return _mapper.Map<TodoListDto>(todoResult);
        }

        public async Task<TodoListItemDto> UpdateTodoListItem(TodoListItemDto todoListItem)
        {
            var mappedTodoItem = _mapper.Map<TodoListItem>(todoListItem);
            var todoItemResult = await _todoListDAL.UpdateTodoListItem(mappedTodoItem);

            return _mapper.Map<TodoListItemDto>(todoItemResult);
        }
    }
}
