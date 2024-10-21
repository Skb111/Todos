using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.AppUser.Models;

namespace Todo.Application.Features.AuthUser.Commands.DeleteUser
{
    public record DeleteUserCommand(UserRequestModelId UserRequest) : IRequest<bool?>;

}
 