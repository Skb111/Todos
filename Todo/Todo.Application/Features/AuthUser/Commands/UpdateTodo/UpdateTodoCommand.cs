using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Todo.Entities;
using Todo.Domain.Todo.Models;

namespace Todo.Application.Features.AuthUser.Commands.UpdateTodo
{
    public record UpdateTodoCommand(UserTodoRequestModelUpdate UserTodo) : IRequest<bool>;

}
