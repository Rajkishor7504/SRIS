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

namespace SRIS.Application.EthnicityMasters.Commands.DeleteEthnicityMasterItem
{
    public class DeleteEthnicityMasterCommand : IRequest<int>
    {
        public int ethnicityid { get; set; }
    }
    public class DeleteEthnicityMasterCommandHandler : IRequestHandler<DeleteEthnicityMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteEthnicityMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteEthnicityMasterCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_ethnicity.FindAsync(request.ethnicityid);
            try
            {
                count = _context.t_hhr_demographicmember.Where(x => x.ethnicgroup == request.ethnicityid && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Demographicmember), request.ethnicityid);
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
        //public async Task<Unit> Handle(DeleteEthnicityMasterCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.m_master_ethnicity.FindAsync(request.ethnicityid);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(EthnicityMaster), request.ethnicityid);
        //    }

        //    _context.m_master_ethnicity.Remove(entity);

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Unit.Value;
        //}

    }
}
