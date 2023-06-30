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

namespace SRIS.Application.liveLiHoodMasters.Commands.DeleteliveLiHoodMasterItem
{
    public class DeleteliveLiHoodMasterCommand : IRequest<int>
    {
        public int livelihoodid { get; set; }
    }
    public class DeleteliveLiHoodMasterCommandHandler : IRequestHandler<DeleteliveLiHoodMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteliveLiHoodMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteliveLiHoodMasterCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_livelihood.FindAsync(request.livelihoodid);
            try
            {
                count = _context.t_hhr_impactofshocks.Where(x => x.shockforlivestockid == request.livelihoodid && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Impactofshocks), request.livelihoodid);
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
        //public async Task<Unit> Handle(DeleteliveLiHoodMasterCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.m_master_livelihood.FindAsync(request.livelihoodid);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(LiveliHood), request.livelihoodid);
        //    }

        //    _context.m_master_livelihood.Remove(entity);
        //    //entity.updatedon = DateTime.Now;
        //    //entity.deletedflag = true;

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Unit.Value;
        //}

    }
}