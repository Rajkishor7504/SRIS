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

namespace SRIS.Application.RelationMasters.Commands.DeleteRealtionMasterItem
{
   public class DeleteRelationMasterCommand : IRequest<int>
    {
        public int id { get; set; }
    }
    public class DeleteMasterCommandHandler : IRequestHandler<DeleteRelationMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteRelationMasterCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_relation.FindAsync(request.id);
            try
            {
                count = _context.t_hhr_demographicmember.Where(x => x.b04_relationwithhh == request.id && x.deletedflag == false).Count();

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
                    //_context.m_master_relation.Remove(entity);
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
        //public async Task<Unit> Handle(DeleteRelationMasterCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.m_master_relation.FindAsync(request.id);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(RelationMaster), request.id);
        //    }

        //    _context.m_master_relation.Remove(entity);

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Unit.Value;
        //}
    }
}
