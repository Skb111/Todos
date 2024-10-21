using MediatR;
using Todo.Domain.AppUser.Entities;
using Todo.Domain.Todo.Abstractions;

namespace Todo.Application.Features.AuthUser.Commands.CreateUser
{
    internal sealed class CreateUserCommandHandler(IUserRepository repository) : IRequestHandler<CreateUserCommand, ApplicationUser>
    {
        public async Task<ApplicationUser> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var req = request.userRequest;

            var appUser = new ApplicationUser(req.Email, req.Username, req.Password);
            appUser.CreatedAt = DateTime.UtcNow;
            appUser.Status = UserStatus.Active;
            appUser.PasswordSalt = Guid.NewGuid().ToString();
             
            var user = await repository.CreateAsync(appUser);

            return user;
        }
    }
    
}
