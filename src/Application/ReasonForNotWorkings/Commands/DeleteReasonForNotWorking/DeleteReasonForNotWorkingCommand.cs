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

namespace SRIS.Application.ReasonForNotWorkings.Commands.DeleteReasonForNotWorking
{
    public class DeleteReasonForNotWorkingCommand:IRequest<int>
    {
        public int reasonid { get; set; }
    }
    public class DeleteReasonForNotWorkingCommandHandler : IRequestHandler<DeleteReasonForNotWorkingCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteReasonForNotWorkingCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteReasonForNotWorkingCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_reasonfornotworking.FindAsync(request.reasonid);
            try
            {
                count = _context.t_hhr_employment.Where(x => x.e06_reasonfornotworking == request.reasonid && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Employment), request.reasonid);
                }
                if (count > 0)
                {
                    retval = 402;
                }
                else
                {
                    //_context.m_master_reasonfornotworking.Remove(entity);
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
            //return Unit.Value;
            return retval;
        }
        //public async Task<Unit> Handle(DeleteReasonForNotWorkingCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.m_master_reasonfornotworking.FindAsync(request.reasonid);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(ReasonForNotWorking), request.reasonid);
        //    }

        //    _context.m_master_reasonfornotworking.Remove(entity);

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Unit.Value;
        //}
    }
}

