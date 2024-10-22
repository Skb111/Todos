using FluentValidation;
using MediatR;
using Todo.Domain.AppUser.Entities;
using Todo.Domain.Todo.Abstractions;

namespace Todo.Application.Features.AuthUser.Commands.CreateUser
{
    internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ApplicationUser>
    {
        private readonly IValidator<CreateUserCommand> _validator;
        private readonly IUserRepository repository;
        public CreateUserCommandHandler(IValidator<CreateUserCommand> validator, IUserRepository _repository)
        {
            _validator = validator;
            repository = _repository;
        }

        public async Task<ApplicationUser> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            
            var validatorResult = await _validator.ValidateAsync(request);

            if (!validatorResult.IsValid) throw new ValidationException(validatorResult.Errors);

            
            var req = request.userRequest;

            var appUser = new ApplicationUser(req.Email, req.Username, req.Password);
            appUser.CreatedAt = DateTime.UtcNow;
            appUser.Status = UserStatus.Active;
            appUser.PasswordSalt = Guid.NewGuid().ToString();
             
            var user = await repository.CreateAsync(appUser);

            return user;
        }
    }
    
}
