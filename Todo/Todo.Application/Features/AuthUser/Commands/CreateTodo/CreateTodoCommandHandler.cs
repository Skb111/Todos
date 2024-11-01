using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.AppUser.Entities;
using Todo.Domain.Todo.Abstractions;
using Todo.Domain.Todo.Entities;

namespace Todo.Application.Features.AuthUser.Commands.CreateTodo
{
    internal sealed class CreateTodoCommandHandler(ITodoRepository todoRepository, IUserRepository userRepository) : IRequestHandler<CreateTodoCommand, UserTodo>
    {
        public async Task<UserTodo> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var req = request.UserTodo;
            var applicationUser = await userRepository.FindById(request.userId);
            if (applicationUser == null)
            {
                throw new Exception("User not found");
            }
            var userTodo = new UserTodo(req.Title, req.Description);
            userTodo.Status = TodoStatus.New;
            userTodo.ApplicationUser = applicationUser;
            userTodo.CreatedAt = DateTime.UtcNow;
            userTodo.FinishedAt = null;
            var Todo = await todoRepository.CreateAsync(userTodo);
            return Todo;
        }
    }
}
