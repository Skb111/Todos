using MediatR;
using Todo.Domain.AppUser.Entities;
using Todo.Domain.Todo.Abstractions;

namespace Todo.Application.Features.AuthUser.Queries.GetActiveUser
{
    internal sealed class UserIsActiveQueryHandler(IUserRepository repository) : IRequestHandler<UserIsActiveQuery, ApplicationUser?>
    {
        public async Task<ApplicationUser?> Handle(UserIsActiveQuery request, CancellationToken cancellationToken)
        {
            var req = await repository.FindById(request.ApplicationUserId);
            if (req != null && req.Status == UserStatus.Active)
            {
                return req;
            }
            return null;
        }
    }
}
