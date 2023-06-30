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

namespace SRIS.Application.MainJobActivityMaster.Commands.DeleteMainJobActivityMaster
{
    public class DeleteMainJobActivityCommand:IRequest<int>
    {
        public int activityid { get; set; }
    }
    public class DeleteMainJobActivityCommandHandler : IRequestHandler<DeleteMainJobActivityCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMainJobActivityCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteMainJobActivityCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_mainjobactivity.FindAsync(request.activityid);
            try
            {
                count = _context.t_hhr_employment.Where(x => x.e02_mainjobactivitylastthirtydays == request.activityid && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Employment), request.activityid);
                }
                if (count > 0)
                {
                    retval = 402;
                }
                else
                {
                    //_context.m_master_mainjobactivity.Remove(entity);
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
        //public async Task<Unit> Handle(DeleteMainJobActivityCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.m_master_mainjobactivity.FindAsync(request.activityid);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(MainJobActivity), request.activityid);
        //    }

        //    _context.m_master_mainjobactivity.Remove(entity);

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Unit.Value;
        //}
    }
}
