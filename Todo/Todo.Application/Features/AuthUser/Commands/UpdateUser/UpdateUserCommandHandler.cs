using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.AppUser.Entities;
using Todo.Domain.Todo.Abstractions;

namespace Todo.Application.Features.AuthUser.Commands.UpdateUser
{
    internal sealed class UpdateUserCommandHandler(IUserRepository repository) : IRequestHandler<UpdateUserCommand, bool>
    {
        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var req = request.userRequest;
            var user = await repository.FindById(req.ApplicationUserId);

            if (user != null && user.Status == UserStatus.Active)
            {
                user.Username = req.Username;
                user.Password = req.Password;
                user.Email = req.Email;
                user.Password = req.Password;
                user.PasswordSalt = Guid.NewGuid().ToString();
                user.CreatedAt = DateTime.UtcNow; 


                var userupdate = await repository.UpdateAsync(user);

                return userupdate;
            }
            return false;
        }
    }
}
