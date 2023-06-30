using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.AssignLinkToRoleMasters.Commands.DeleteAssignLinkToRoleItemm
{
    public class DeleteAssignLinkToRoleMasterCommand : IRequest
    {
        public int linkaccessid { get; set; }
    }
    public class DeleteAssignLinkToRoleMasterCommandHandler : IRequestHandler<DeleteAssignLinkToRoleMasterCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteAssignLinkToRoleMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        #region "To delete the record for User Access Link"
       
        public async Task<Unit> Handle(DeleteAssignLinkToRoleMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.m_adm_assignlinkrolewise.FindAsync(request.linkaccessid);

            if (entity == null)
            {
                throw new NotFoundException(nameof(AssignLinkToRoleMaster), request.linkaccessid);
            }

            entity.updatedby = 1;
            entity.deletedflag = true;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        #endregion
    }
}
