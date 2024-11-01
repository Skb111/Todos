using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Todo.Models;

namespace Todo.Application.Features.AuthUser.Commands.DeleteTodo
{
    public record DeleteTodoCommand(UserTodoRequestModelId UserTodo) : IRequest<bool?>;

}
