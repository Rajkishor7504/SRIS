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

namespace SRIS.Application.AidTypeMasters.Commands.DeleteAidTypeMasterItem
{
    public class DeleteAidTypeMasterCommand:IRequest<int>
    {
        public int aidid { get; set; }
    }
    public class DeleteAidTypeMasterCommandHandler:IRequestHandler<DeleteAidTypeMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;
        public DeleteAidTypeMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteAidTypeMasterCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_hhr_aid.FindAsync(request.aidid);
            try
            {
                count = _context.t_hhr_incomeaiddetail.Where(x => x.aidid == request.aidid && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Incomeaiddetail), request.aidid);
                }
                if (count > 0)
                {
                    retval = 402;
                }
                else
                {
                    entity.updatedby = 1;
                    entity.deletedflag = true;
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
        //  public async Task<Unit> Handle(DeleteAidTypeMasterCommand request, CancellationToken CancellationToken)
        //{
        //    var entity = await _context.m_hhr_aid.FindAsync(request.aidid);
        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(AidType), request.aidid);
        //    }
        //    _context.m_hhr_aid.Remove(entity);
        //    await _context.SaveChangesAsync(CancellationToken);
        //    return Unit.Value;
        //}
    }
}
