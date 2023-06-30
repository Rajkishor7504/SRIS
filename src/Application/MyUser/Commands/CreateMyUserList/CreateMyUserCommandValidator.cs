using FluentValidation;

namespace SRIS.Application.MyUsers.Commands.CreateMyUser
{
    public class CreateMyUserCommandValidator : AbstractValidator<CreateMyUserCommand>
    {
        //public CreateMyUserCommandValidator()
        //{
        //    RuleFor(v => v.username)
        //        .MaximumLength(200)
        //        .NotEmpty();
        //}
    }
}
