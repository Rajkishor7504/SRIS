using FluentValidation;

namespace SRIS.Application.TodoItems.Commands.UpdateTodoItem
{
    public class UpdateMasterCommandValidator : AbstractValidator<UpdateTodoItemCommand>
    {
        public UpdateMasterCommandValidator()
        {
            RuleFor(v => v.Title)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
