using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.AssignLinkToRoleMasters.Commands.UpdateAssignLinkMasterItem
{
    public class UpdateAssignLinkMasterCommand : IRequest
    {
        public int linkaccessid { get; set; }
        public int plinkid { get; set; }
        //  public int userid { get; set; }
        public int roleid { get; set; }
        public AssignLinkToRoleType accesstype { get; set; }
    }
    public class UpdateAssignLinkMasterCommandHandler : IRequestHandler<UpdateAssignLinkMasterCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateAssignLinkMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        #region "To update record for User Access Link"
       
        public async Task<Unit> Handle(UpdateAssignLinkMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.m_adm_assignlinkrolewise.FindAsync(request.linkaccessid);

            if (entity == null)
            {
                throw new NotFoundException(nameof(AssignLinkToRoleMaster), request.plinkid);
            }

            entity.plinkid = request.plinkid;
            entity.roleid = request.roleid;
            entity.accesstype = request.accesstype;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        #endregion
    }
}