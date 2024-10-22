using MediatR;
using Todo.Domain.AppUser.Entities;
using Todo.Domain.Todo.Abstractions;
using Todo.Shared.Exceptions;

namespace Todo.Application.Features.AuthUser.Queries.GetUserByUserName
{
    internal sealed class ByUserNameQueryHandler(IUserRepository repository) : IRequestHandler<ByUserNameQuery, ApplicationUser?>
    {
        public async Task<ApplicationUser?> Handle(ByUserNameQuery request, CancellationToken cancellationToken)
        {
            var user = await repository.FindByUserName(request.Username);

            if (user == null) throw new NotFoundException("User not found");

            return user;
        }
    }
}
