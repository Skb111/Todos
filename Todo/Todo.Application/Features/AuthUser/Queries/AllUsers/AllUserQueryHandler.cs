using MediatR;
using Todo.Domain.AppUser.Entities;
using Todo.Domain.Todo.Abstractions;

namespace Todo.Application.Features.AuthUser.Queries.AllUsers
{
    internal sealed class AllUserQueryHandler(IUserRepository repository) : IRequestHandler<AllUserQuery, IList<ApplicationUser>>
    {
        public async Task<IList<ApplicationUser>> Handle(AllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await repository.GetAllAsync();

            return users;
        }
    }
} 
