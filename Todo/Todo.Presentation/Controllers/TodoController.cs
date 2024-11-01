﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Features.AuthUser.Commands.CreateTodo;
using Todo.Application.Features.AuthUser.Commands.DeleteTodo;
using Todo.Application.Features.AuthUser.Commands.UpdateTodo;
using Todo.Application.Features.AuthUser.Queries.GetAllTodo;
using Todo.Domain.Todo.Models;

namespace Todo.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IMediator mediator;

        public TodoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("todos")]
        public async Task<IActionResult> AddTodo(Guid userId, UserTodoRequestModel request)
        {
            var userReq = new CreateTodoCommand(userId, request);
            var user = await mediator.Send(userReq);
            return Ok(user);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateTodo(UserTodoRequestModelUpdate request)
        {
            var updateResult = await mediator.Send(new UpdateTodoCommand(request));

            if (!updateResult)
            {
                return NotFound("User not found or not active.");
            }

            return Ok("User updated successfully.");
        }

        [HttpDelete]
        [Route("todo/delete")]
        public async Task<IActionResult> DeleteTodo(Guid applicationUserId, Guid todoId)
        {
            var userRequest = new UserTodoRequestModelId(applicationUserId, todoId);

            var user = await mediator.Send(new DeleteTodoCommand(userRequest));

            if (user == null)
            {
                return NotFound("User does not exist.");
            }

            return Ok($"Todo with {todoId} is deleted successfully !!!");
        }

        [HttpGet]
        [Route("todos")]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = await mediator.Send(new AllTodoQuery());
            return Ok(user);
        }
    }
}