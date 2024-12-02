using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Todo.Abstractions;
using Todo.Domain.Todo.Entities;

namespace Todo.Application.Features.AuthUser.Queries.GetTodoById
{
    internal sealed class ByTodoIdQueryHandler(ITodoRepository todoRepository, IUserRepository repository) : IRequestHandler<ByTodoIdQuery, UserTodo?>
    {
        public async Task<UserTodo?> Handle(ByTodoIdQuery request, CancellationToken cancellationToken)
        {
            //var req = request.UserTodo;
            var user = await repository.FindById(request.applicationUserId);
            if (user != null)
            {
                var todo = await todoRepository.FindById(request.todoId);
                return todo;
            }
            return null;
        }
    }
}
