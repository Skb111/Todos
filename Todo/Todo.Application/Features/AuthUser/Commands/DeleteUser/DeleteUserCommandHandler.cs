using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Todo.Abstractions;

namespace Todo.Application.Features.AuthUser.Commands.DeleteUser
{
    internal sealed class DeleteUserCommandHandler(IUserRepository repository) : IRequestHandler<DeleteUserCommand, bool?>
    {
        public async Task<bool?> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var req = request.UserRequest;
            var user = await repository.FindById(req.ApplicationUserId); 
            if (user != null)
            {
                return await repository.DeleteAsync(user.ApplicationUserId);
            }
            return false;  
        }
    }
}
