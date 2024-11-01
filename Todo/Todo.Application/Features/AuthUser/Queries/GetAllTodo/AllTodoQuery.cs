using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Todo.Entities;

namespace Todo.Application.Features.AuthUser.Queries.GetAllTodo
{
    public record AllTodoQuery : IRequest<IList<UserTodo>>;

}
