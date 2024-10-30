using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.AppUser.Entities;
using Todo.Domain.AppUser.Models;

namespace Todo.Application.Features.AuthUser.Queries.GetUserById
{
    public record ByUserIdQuery(Guid ApplicationUserId) : IRequest<ApplicationUser?>;

}
