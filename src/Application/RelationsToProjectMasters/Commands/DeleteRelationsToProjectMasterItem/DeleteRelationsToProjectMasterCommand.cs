using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.RelationsToProjectMasters.Commands.DeleteRelationsToProjectMasterItem
{
    public class DeleteRelationsToProjectMasterCommand : IRequest
    {
        public int relationid { get; set; }
    }
    public class DeleteRelationsToProjectMasterMasterCommandHandler : IRequestHandler<DeleteRelationsToProjectMasterCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteRelationsToProjectMasterMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRelationsToProjectMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.m_master_relationofproject.FindAsync(request.relationid);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(RelationsToProjectMaster), request.relationid);
                }

                //_context.m_master_relationofproject.Remove(entity);

                //await _context.SaveChangesAsync(cancellationToken);
                entity.updatedby = 1;
                entity.deletedflag = true;
                entity.updatedon = DateTime.Now;
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
