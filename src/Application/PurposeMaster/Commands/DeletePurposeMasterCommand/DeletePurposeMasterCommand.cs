using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.PurposeMaster.Commands.DeletePurposeMasterCommand
{
    public class DeletePurposeMasterCommand : IRequest<int>
   
    {
        public int purposeid { get; set; }
    }
    public class DeletePurposeMasterCommandHandler : IRequestHandler<DeletePurposeMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeletePurposeMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeletePurposeMasterCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_purpose.FindAsync(request.purposeid);
          
            if (entity == null)
            {
                throw new NotFoundException(nameof(Purpose), request.purposeid);
            }
            if (count > 0)
            {
                retval = 402;
            }
            else
            {

                //_context.m_master_purpose.Remove(entity);

                //await _context.SaveChangesAsync(cancellationToken);
                //entity.deletedflag = true;
                entity.updatedby = 1;
                entity.deletedflag = true;
                entity.updatedon = DateTime.Now;
                await _context.SaveChangesAsync(cancellationToken);
                //return Unit.Value;
                retval = 200;
            }
            return retval;
        }
    }
}

