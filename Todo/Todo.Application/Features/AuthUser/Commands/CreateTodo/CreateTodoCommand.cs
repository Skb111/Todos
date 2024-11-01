using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Todo.Entities;
using Todo.Domain.Todo.Models;

namespace Todo.Application.Features.AuthUser.Commands.CreateTodo
{
    public record CreateTodoCommand(Guid userId, UserTodoRequestModel UserTodo) : IRequest<UserTodo>;

}
