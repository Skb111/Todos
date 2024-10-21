using MediatR;
using Todo.Domain.AppUser.Entities;
using Todo.Domain.Todo.Abstractions;

namespace Todo.Application.Features.AuthUser.Queries.GetActiveUser
{
    internal sealed class UserIsActiveQueryHandler(IUserRepository repository) : IRequestHandler<UserIsActiveQuery, ApplicationUser?>
    {
        public async Task<ApplicationUser?> Handle(UserIsActiveQuery request, CancellationToken cancellationToken)
        {
            var req = request.userRequest;
            var user = await repository.FindById(req.ApplicationUserId);
            if (user != null && user.Status == UserStatus.Active)
            {
                return user;
            }
            return null;
        }
    }
}
