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

namespace SRIS.Application.ResidenceMasters.Commands.DeleteResidenceMasterItem
{
    public class DeleteResidanceMasterCommand : IRequest<int>
    {
        public int id { get; set; }
    }
    public class DeleteMasterCommandHandler : IRequestHandler<DeleteResidanceMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteResidanceMasterCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.M_Master_Residence.FindAsync(request.id);
            try
            {
                count = _context.t_hhr_demographicmember.Where(x => x.b05_residencestatus == request.id && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Demographicmember), request.id);
                }
                if (count > 0)
                {
                    retval = 402;
                }
                else
                {
                    //_context.M_Master_Residence.Remove(entity);
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
        //public async Task<Unit> Handle(DeleteResidanceMasterCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.M_Master_Residence.FindAsync(request.id);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(ResidenceMaster), request.id);
        //    }

        //    _context.M_Master_Residence.Remove(entity);

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Unit.Value;
        //}

    }
}
