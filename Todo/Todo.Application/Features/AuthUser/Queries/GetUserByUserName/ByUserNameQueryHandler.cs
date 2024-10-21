using MediatR;
using Todo.Domain.AppUser.Entities;
using Todo.Domain.Todo.Abstractions;

namespace Todo.Application.Features.AuthUser.Queries.GetUserByUserName
{
    internal sealed class ByUserNameQueryHandler(IUserRepository repository) : IRequestHandler<ByUserNameQuery, ApplicationUser?>
    {
        public async Task<ApplicationUser?> Handle(ByUserNameQuery request, CancellationToken cancellationToken)
        {
            var req = request.userRequest;
            return await repository.FindByUserName(req.Username);
        }
    }
}
