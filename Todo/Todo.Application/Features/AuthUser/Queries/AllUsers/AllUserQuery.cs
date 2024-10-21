using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.AppUser.Entities;

namespace Todo.Application.Features.AuthUser.Queries.AllUsers
{
    public record AllUserQuery:IRequest<IList<ApplicationUser>>;

}
 