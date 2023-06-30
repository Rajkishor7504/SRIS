using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using SRIS.Domain.Entities.MasterDepenciesEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.ReasonForStopSchools.Commands.DeleteReasonForStopSchoolMaster
{
   public class DeleteReasonForStopSchoolCommand: IRequest<int>
    {
        public int reasonid { get; set; }
    }
    public class DeleteReasonForStopSchoolCommandHandler : IRequestHandler<DeleteReasonForStopSchoolCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteReasonForStopSchoolCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteReasonForStopSchoolCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_reasonforstopschool.FindAsync(request.reasonid);
            try
            {
                count = _context.t_hhr_education.Where(x => x.c08_whystoppedgoingschool == request.reasonid && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Education), request.reasonid);
                }
                if (count > 0)
                {
                    retval = 402;
                }
                else
                {
                    //_context.m_master_reasonforstopschool.Remove(entity);
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
        //public async Task<Unit> Handle(DeleteReasonForStopSchoolCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.m_master_reasonforstopschool.FindAsync(request.reasonid);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(ReasonForStopSchool), request.reasonid);
        //    }

        //    _context.m_master_reasonforstopschool.Remove(entity);

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Unit.Value;
        //}
    }
}
