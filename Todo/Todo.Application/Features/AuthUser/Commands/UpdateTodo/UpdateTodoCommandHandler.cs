using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.AppUser.Entities;
using Todo.Domain.Todo.Abstractions;
using Todo.Domain.Todo.Entities;
using Todo.Shared.Exceptions;

namespace Todo.Application.Features.AuthUser.Commands.UpdateTodo
{
    internal sealed class UpdateTodoCommandHandler(IUserRepository repository, ITodoRepository todoRepository) : IRequestHandler<UpdateTodoCommand, bool>
    {
        public async Task<bool> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var req = request.UserTodo;
            var user = await repository.FindById(req.ApplicationUserId);
            if (user != null && user.Status == UserStatus.Active)
            {
               var todo = await todoRepository.FindById(req.todoId);
                if (todo != null /*&& todo.Status == TodoStatus.New*/)
                {
                    todo.Title = req.Title;
                    todo.Description = req.Description;
                    todo.Status = TodoStatus.Completed;
                    todo.CreatedAt = DateTime.Now;
                    todo.FinishedAt = null;
                }
                var result = await todoRepository.UpdateAsync(todo);
                return result;
            }
            return false;
        }
    }
}
