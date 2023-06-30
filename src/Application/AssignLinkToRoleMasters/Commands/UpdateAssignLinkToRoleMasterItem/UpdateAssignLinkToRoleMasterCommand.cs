using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.AssignLinkToRoleMasters.Commands.UpdateAssignLinkToRoleMasterItem
{
    public class UpdateAssignLinkToRoleMasterCommand : IRequest
    {
        public int linkaccessid { get; set; }
        public int plinkid { get; set; }
        //  public int userid { get; set; }
        public int roleid { get; set; }
        public bool deletedflag { get; set; }
        public AssignLinkToRoleType accesstype { get; set; }
    }
    public class UpdateAssignLinkToRoleMasterCommandHandler : IRequestHandler<UpdateAssignLinkToRoleMasterCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateAssignLinkToRoleMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        #region "To update record for User Access Link"

        public async Task<Unit> Handle(UpdateAssignLinkToRoleMasterCommand request, CancellationToken cancellationToken)
        {

            var entity = await _context.m_adm_assignlinkrolewise.FindAsync(request.linkaccessid);

            if (entity == null)
            {
                throw new NotFoundException(nameof(AssignLinkToRoleMaster), request.plinkid);
            }
            if (request.deletedflag)
            {
                entity.deletedflag = true;
            }
            else
            {
                entity.plinkid = request.plinkid;
                entity.roleid = request.roleid;
                entity.accesstype = request.accesstype;
                entity.deletedflag = false;
            }
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }

        #endregion
    }
}