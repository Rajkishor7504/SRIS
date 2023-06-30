using FluentValidation;
using SRIS.Application.MyUsers.Commands.UpdateMyUser;

namespace SRIS.Application.Masters.Commands.UpdateMaster
{
    public class UpdateMyUserCommandValidator : AbstractValidator<UpdateMyUserCommand>
    {
        public UpdateMyUserCommandValidator()
        {
            RuleFor(v => v.username)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
