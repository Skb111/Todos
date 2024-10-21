using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.AppUser.Entities;
using Todo.Domain.AppUser.Models;

namespace Todo.Application.Features.AuthUser.Commands.CreateUser
{
    public record CreateUserCommand(UserRequestModel userRequest) :IRequest<ApplicationUser>;
}
