using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Todo.Abstractions;
using Todo.Domain.Todo.Entities;

namespace Todo.Application.Features.AuthUser.Queries.GetAllTodo
{
    internal sealed class AllTodoQueryHandler(ITodoRepository todoRepository) : IRequestHandler<AllTodoQuery, IList<UserTodo>>
    {
        public async Task<IList<UserTodo>> Handle(AllTodoQuery request, CancellationToken cancellationToken)
        {
            var todos = await todoRepository.GetAllAsync();
            return todos;
        }
    }
}
