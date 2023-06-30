using SRIS.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Masters.Commands.CreateMaster
{
    public class CreateMasterCommandValidator : AbstractValidator<CreateMasterCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateMasterCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
                .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");
        }

        public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
        {
            return await _context.masters
                .AllAsync(l => l.Name != title);
        }
    }
}
