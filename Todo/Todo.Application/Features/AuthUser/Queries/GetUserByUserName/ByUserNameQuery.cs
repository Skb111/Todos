using MediatR;
using Todo.Domain.AppUser.Entities;
using Todo.Domain.AppUser.Models;

namespace Todo.Application.Features.AuthUser.Queries.GetUserByUserName
{
    public record ByUserNameQuery(UserRequestModel userRequest) : IRequest<ApplicationUser?>;

}
