using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.PMTMasters.Commands.DeletePMTMasterItem
{
    public class DeletePMTMasterCommand : IRequest
    {
        public int categoryid { get; set; }
    }
    public class DeletePMTMasterCommandHandler : IRequestHandler<DeletePMTMasterCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeletePMTMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePMTMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.m_pmt_category.FindAsync(request.categoryid);

            if (entity == null)
            {
                throw new NotFoundException(nameof(PmtMasterN), request.categoryid);
            }

            //_context.m_master_pmt.Remove(entity);

            //await _context.SaveChangesAsync(cancellationToken);
            entity.updatedby = 1;
            entity.deletedflag = true;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

}
