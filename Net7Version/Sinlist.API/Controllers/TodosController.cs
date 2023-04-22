using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sinlist.BusinessLogic.Abstract;
using Sinlist.Shared.DTOs.Sinlists;
using Sinlist.Shared.Responses;

namespace Sinlist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : CustomBaseController
    {
        private readonly ITodoListBLL _todoListBLL;
        private readonly ITodoListItemBLL _todoListItemBLL;

        public TodosController(ITodoListBLL todoListBLL, ITodoListItemBLL todoListItemBLL)
        {
            _todoListBLL = todoListBLL;
            _todoListItemBLL = todoListItemBLL;
        }

        [HttpPost(template: "add_todo")]
        public async Task<IActionResult> AddTodoList([FromBody] TodoListDto todoListDto)
        {
            var todoId = await _todoListBLL.AddTodoList(todoListDto);
            return CreateActionResult(Response<int>.Success(200, todoId));
        }

        [HttpPost(template: "add_todolist_item")]
        public async Task<IActionResult> AddTodoListItem([FromBody] TodoListItemDto todoListItemDto)
        {
            var todoItemId = await _todoListItemBLL.AddTodolistItem(todoListItemDto);
            return CreateActionResult(Response<int>.Success(200, todoItemId));
        }

        [HttpPut(template: "update")]
        public async Task<IActionResult> UpdateTodoList([FromBody] TodoListDto todoListDto)
        {
            await _todoListBLL.UpdateTodoList(todoListDto);
            return CreateActionResult(Response<TodoListDto>.Success(200, todoListDto));
        }

        [HttpPut(template: "update_todolist_item")]
        public async Task<IActionResult> UpdateTodoListItem([FromBody] TodoListItemDto todoListItemDto)
        {
            await _todoListItemBLL.UpdateTodoListItem(todoListItemDto);
            return CreateActionResult(Response<TodoListItemDto>.Success(200, todoListItemDto));
        }

        [HttpDelete(template: "delete_todolist")]
        public async Task<IActionResult> DeleteTodoList([FromQuery] int todoListId)
        {
            await _todoListBLL.DeleteTodolist(todoListId);
            return CreateActionResult(Response<bool>.Success(200, true));
        }

        [HttpDelete(template: "delete_todolist_item")]
        public async Task<IActionResult> DeleteTodoListItem([FromQuery] int todoListItemId)
        {
            await _todoListItemBLL.DeleteTodoListItem(todoListItemId);
            return CreateActionResult(Response<bool>.Success(200, true));
        }

        [HttpGet(template: "get_todolist")]
        public async Task<IActionResult> GetTodoLists([FromQuery] string deviceInfo)
        {
            var todos = await _todoListBLL.GetTodoLists(deviceInfo);
            return CreateActionResult(Response<List<TodoListDto>>.Success(200, todos));
        }

        [HttpGet(template: "get_todolist_by_id")]
        public async Task<IActionResult> GetTodolistById([FromQuery] int todolistId)
        {
            var todo = await _todoListBLL.GetTodoListById(todolistId);
            return CreateActionResult(Response<TodoListDto>.Success(200, todo));
        }

        [HttpGet(template: "get_todolist_items_by_id")]
        public async Task<IActionResult> GetTodolistItemsById([FromQuery] int todolistId)
        {
            var todoItems = await _todoListItemBLL.GetTodoListItemsById(todolistId);
            return CreateActionResult(Response<List<TodoListItemDto>>.Success(200, todoItems));
        }

    }
}
