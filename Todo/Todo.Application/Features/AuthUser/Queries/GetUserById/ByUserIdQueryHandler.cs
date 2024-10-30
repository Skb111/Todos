using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Features.AuthUser.Queries.GetUserByEmail;
using Todo.Domain.AppUser.Entities;
using Todo.Domain.Todo.Abstractions;

namespace Todo.Application.Features.AuthUser.Queries.GetUserById
{
    internal sealed class ByUserIdQueryHandler(IUserRepository repository) : IRequestHandler<ByUserIdQuery, ApplicationUser?>
    {
        public async Task<ApplicationUser?> Handle(ByUserIdQuery request, CancellationToken cancellationToken)
        {
            var req = await repository.FindById(request.ApplicationUserId);
            return req;  
        }
    }
}
