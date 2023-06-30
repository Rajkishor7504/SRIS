using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.NationalityMasters.Commands.DeleteNationalityMasterItem
{
    public class DeleteNationalityMasterCommand : IRequest
    {
        public int nationalityid { get; set; }
    }
    public class DeleteMasterCommandHandler : IRequestHandler<DeleteNationalityMasterCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteNationalityMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.m_master_nationalitytbl.FindAsync(request.nationalityid);

            if (entity == null)
            {
                throw new NotFoundException(nameof(NationalityMaster), request.nationalityid);
            }

            //_context.m_master_nationalitytbl.Remove(entity);

            //await _context.SaveChangesAsync(cancellationToken);
            entity.updatedby = 1;
            entity.deletedflag = true;
            entity.updatedon = DateTime.Now;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
}
