using FluentValidation;

namespace SRIS.Application.Masters.Commands.UpdateMaster
{
    public class UpdateMasterCommandValidator : AbstractValidator<UpdateMasterCommand>
    {
        public UpdateMasterCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
