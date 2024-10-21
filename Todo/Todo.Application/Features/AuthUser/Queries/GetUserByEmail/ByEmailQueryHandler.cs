using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.AppUser.Entities;
using Todo.Domain.Todo.Abstractions;

namespace Todo.Application.Features.AuthUser.Queries.GetUserByEmail
{
    internal sealed class ByEmailQueryHandler(IUserRepository repository) : IRequestHandler<ByUserEmailQuery, ApplicationUser?>
    {
        public async Task<ApplicationUser?> Handle(ByUserEmailQuery request, CancellationToken cancellationToken)
        {
            var req = request.userRequest;
            return await repository.FindByEmail(req.Email);

        }
    }
}
