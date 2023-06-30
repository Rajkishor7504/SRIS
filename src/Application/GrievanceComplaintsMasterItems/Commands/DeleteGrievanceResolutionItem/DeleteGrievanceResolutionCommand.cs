using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.GrievanceComplaintsMasterItems.Commands.DeleteGrievanceResolutionItem
{
    public class DeleteGrievanceResolutionCommand:IRequest
    {
        public int registrationid { get; set; }
    }
    public class DeleteGrievanceResolutionCommandHandler : IRequestHandler<DeleteGrievanceResolutionCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteGrievanceResolutionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteGrievanceResolutionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.t_grievance_registration.FindAsync(request.registrationid);

            if (entity == null)
            {
                throw new NotFoundException(nameof(GrievanceComplaints), request.registrationid);
            }

            entity.deletedflag = true;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

}


