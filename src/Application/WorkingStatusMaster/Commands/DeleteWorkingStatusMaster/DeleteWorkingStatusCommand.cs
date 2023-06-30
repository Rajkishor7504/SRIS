using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterDepenciesEntities;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.WorkingStatusMaster.Commands.DeleteWorkingStatusMaster
{
    public class DeleteWorkingStatusCommand:IRequest<int>
    {
        public int statusid { get; set; }
    }
    public class DeleteWorkingStatusCommandHandler : IRequestHandler<DeleteWorkingStatusCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteWorkingStatusCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteWorkingStatusCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_workingstatus.FindAsync(request.statusid);
            try
            {
                count = _context.t_hhr_employment.Where(x => x.e05_workingstatus == request.statusid && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Employment), request.statusid);
                }
                if (count > 0)
                {
                    retval = 402;
                }
                else
                {
                    //_context.m_master_workingstatus.Remove(entity);
                    //await _context.SaveChangesAsync(cancellationToken);
                    entity.updatedby = 1;
                    entity.deletedflag = true;
                    entity.updatedon = DateTime.Now;
                    await _context.SaveChangesAsync(cancellationToken);
                    retval = 200;
                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
           
            return retval;
        }
       
    }
}

