using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sinlist.BusinessLogic.Abstract;
using Sinlist.Shared.DTOs.Sinlists;
using Sinlist.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sinlist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodolistBLL _todolistBLL;
        private readonly ILogger<TodosController> _logger;

        public TodosController(ITodolistBLL todolistBLL, ILogger<TodosController> logger)
        {
            _todolistBLL = todolistBLL;
            _logger = logger;
        }

        [HttpPost("add")]
        public async Task<Response<TodoListDto>> AddTodoList(TodoListDto todoList)
        {
            try
            {
                var responseDto = await _todolistBLL.AddTodoList(todoList);
                return await Response<TodoListDto>.Run(responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return await Response<TodoListDto>.Catch(new ResponseError { Message = ex.Message });
            }
        }

        [HttpPost("update")]
        public async Task<Response<TodoListDto>> UpdateTodoList(TodoListDto todoList)
        {
            try
            {
                var responseDto = await _todolistBLL.UpdateTodoList(todoList);
                return await Response<TodoListDto>.Run(responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return await Response<TodoListDto>.Catch(new ResponseError { Message = ex.Message });
            }
        }

        [HttpDelete("delete_todolist")]
        public async Task<Response<bool>> DeleteTodolist(int todoListId)
        {
            try
            {
                var responseDto = await _todolistBLL.DeleteTodolist(todoListId);
                return await Response<bool>.Run(responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return await Response<bool>.Catch(new ResponseError { Message = ex.Message });
            }
        }

        [HttpGet("get_todolist_by_id")]
        public async Task<Response<TodoListDto>> GetTodoListById(int todoListId)
        {
            try
            {
                var responseDto = await _todolistBLL.GetTodoListById(todoListId);
                return await Response<TodoListDto>.Run(responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return await Response<TodoListDto>.Catch(new ResponseError { Message = ex.Message });
            }
        }

        [HttpPost("add_todolist_item")]
        public async Task<Response<TodoListItemDto>> AddTodolistItem(TodoListItemDto todoListItem)
        {
            try
            {
                var responseDto = await _todolistBLL.AddTodolistItem(todoListItem);
                return await Response<TodoListItemDto>.Run(responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return await Response<TodoListItemDto>.Catch(new ResponseError { Message = ex.Message });
            }
        }

        [HttpPost("update_todolist_item")]
        public async Task<Response<TodoListItemDto>> UpdateTodoListItem(TodoListItemDto todoListItem)
        {
            try
            {
                var responseDto = await _todolistBLL.UpdateTodoListItem(todoListItem);
                return await Response<TodoListItemDto>.Run(responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return await Response<TodoListItemDto>.Catch(new ResponseError { Message = ex.Message });
            }
        }

        [HttpDelete("delete_todolist_item")]
        public async Task<Response<bool>> DeleteTodoListItem(int todoListItemId)
        {
            {
                try
                {
                    var responseDto = await _todolistBLL.DeleteTodoListItem(todoListItemId);
                    return await Response<bool>.Run(responseDto);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    return await Response<bool>.Catch(new ResponseError { Message = ex.Message });
                }
            }
        }

        [HttpGet("get_todolist_items_by_id")]
        public async Task<Response<List<TodoListItemDto>>> GetTodoListItemsById(int todoListId)
        {
            try
            {
                var responseDto = await _todolistBLL.GetTodoListItemsById(todoListId);
                return await Response<List<TodoListItemDto>>.Run(responseDto);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);
                return await Response<List<TodoListItemDto>>.Catch(new ResponseError { Message = ex.Message });
            }
        }

        [HttpGet("get_todolist")]
        public async Task<Response<List<TodoListDto>>> GetTodoLists(string deviceInfo)
        {
            try
            {
                var responseDto = await _todolistBLL.GetTodoLists(deviceInfo);
                return await Response<List<TodoListDto>>.Run(responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return await Response<List<TodoListDto>>.Catch(new ResponseError { Message = ex.Message });
            }
        }
    }
}
