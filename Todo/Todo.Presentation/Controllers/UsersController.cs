using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Features.AuthUser.Commands.CreateUser;
using Todo.Application.Features.AuthUser.Commands.DeleteUser;
using Todo.Application.Features.AuthUser.Commands.UpdateUser;
using Todo.Application.Features.AuthUser.Queries.AllUsers;
using Todo.Application.Features.AuthUser.Queries.GetActiveUser;
using Todo.Application.Features.AuthUser.Queries.GetUserByEmail;
using Todo.Application.Features.AuthUser.Queries.GetUserById;
using Todo.Application.Features.AuthUser.Queries.GetUserByUserName;
using Todo.Domain.AppUser.Entities;
using Todo.Domain.AppUser.Models;

namespace Todo.Presentation.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("users")]
        public async Task<IActionResult> AddUser(UserRequestModel request)
        {

            var userReq = new CreateUserCommand(request);
            var user = await mediator.Send(userReq);

            return Ok(user);
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetAllUsers()
        {
                     
            var user = await mediator.Send(new AllUserQuery());

            return Ok(user);
        }

        [HttpGet]
        [Route("users/username/{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var query = new ByUserNameQuery(new UserRequestModel(Email: "", Username: username, Password: ""));
            var user = await mediator.Send(query);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("users/email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var query = new ByUserEmailQuery(new UserRequestModel(Email: email, Username: "", Password: ""));
            var user = await mediator.Send(query);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("users/Id/{applicationUserId}")]
        public async Task<IActionResult> GetUserById(Guid applicationUserId)
        {
            var query = new ByUserIdQuery(new UserRequestModelId( ApplicationUserId : applicationUserId));
            var user = await mediator.Send(query);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("user/is-active/{ApplicationUserId}")]
        public async Task<IActionResult> IsUserActive(Guid ApplicationUserId)
        {
            var userRequest = new UserRequestModelId(ApplicationUserId); 

            var user = await mediator.Send(new UserIsActiveQuery(userRequest));

            if (user == null)
            {
                return NotFound("User is not active or does not exist.");
            }

            return Ok($"User {ApplicationUserId} is active.");
        }

        [HttpPut]
        [Route("user/update")]
        public async Task<IActionResult> UpdateUser(UserRequestModelUpdate request)
        {
            var updateResult = await mediator.Send(new UpdateUserCommand(request));

            if (!updateResult)
            {
                return NotFound("User not found or not active.");
            }

            return Ok("User updated successfully.");
        }


        [HttpDelete]
        [Route("user/delete")]
        public async Task<IActionResult> DeleteUser(Guid ApplicationUserId)
        {
            var userRequest = new UserRequestModelId(ApplicationUserId);

            var user = await mediator.Send(new DeleteUserCommand(userRequest));

            if (user == null)
            {
                return NotFound("User does not exist.");
            }

            return Ok($"User with {ApplicationUserId} is deleted successfully !!!");
        }

    }
}
