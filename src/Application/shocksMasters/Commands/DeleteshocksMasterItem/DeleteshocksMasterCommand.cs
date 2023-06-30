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

namespace SRIS.Application.shocksMasters.Commands.DeleteshocksMasterItem
{
    public class DeleteshocksMasterCommand : IRequest<int>
    {
        public int shockid { get; set; }
    }
    public class DeleteshocksMasterCommandHandler : IRequestHandler<DeleteshocksMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteshocksMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteshocksMasterCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_shocks.FindAsync(request.shockid);
            try
            {
                count = _context.t_hhr_impactofshocks.Where(x => x.shockforcropid == request.shockid && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Impactofshocks), request.shockid);
                }
                if (count > 0)
                {
                    retval = 402;
                }
                else
                {
                    //_context.m_master_shocks.Remove(entity);
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
        //public async Task<Unit> Handle(DeleteshocksMasterCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.m_master_shocks.FindAsync(request.shockid);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(Shocks), request.shockid);
        //    }

        //    _context.m_master_shocks.Remove(entity);
        //    //entity.updatedon = DateTime.Now;
        //    //entity.deletedflag = true;

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Unit.Value;
        //}

    }
}