using FluentValidation;
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


    public class CreateUserValidation:AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidation()
        {
            RuleFor(x => x.userRequest.Email).NotEmpty().WithMessage("Email is missing");

            RuleFor(x => x.userRequest.Username).NotEmpty().WithMessage("Username is missing");
        }
    }
}
