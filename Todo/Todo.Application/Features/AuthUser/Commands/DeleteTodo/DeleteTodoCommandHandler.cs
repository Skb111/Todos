using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Todo.Abstractions;

namespace Todo.Application.Features.AuthUser.Commands.DeleteTodo
{
    internal sealed class DeleteTodoCommandHandler(IUserRepository repository, ITodoRepository todoRepository) : IRequestHandler<DeleteTodoCommand, bool?>
    {
        public async Task<bool?> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            var req = request.UserTodo;
            var user = await repository.FindById(req.applicationUserId);
            if (user != null)
            {
                var todo = await todoRepository.FindById(req.todoId);
                return await todoRepository.DeleteAsync(user.ApplicationUserId, todo.TodoId);
            }
            return false;
        }
    }
}
