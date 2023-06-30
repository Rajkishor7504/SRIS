using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.AssignLinkToRoleMasters.Commands
{
    public class CreateAssignLinkToRoleMasterCommand : IRequest<int>
    {
        public int linkaccessid { get; set; }
      
        public int plinkid { get; set; }
        
        public int roleid { get; set; }
        public int userid { get; set; }
        public AssignLinkToRoleType accesstype  { get; set; }
    } 
    public class CreateAssignLinkToRoleMasterCommandHandler : IRequestHandler<CreateAssignLinkToRoleMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateAssignLinkToRoleMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

       // #region "To Create a new record for User Access Link"
        
        public async Task<int> Handle(CreateAssignLinkToRoleMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = new AssignLinkToRoleMaster();
            try
            {
                entity.roleid = request.roleid;
                entity.accesstype = request.accesstype;
                entity.createdby = 1;
                entity.updatedby = 1;
                entity.deletedflag = false;
                entity.plinkid = request.plinkid;
                //entity.userid = request.userid;
                entity.linkaccessid = request.linkaccessid;
                if (entity.linkaccessid == 0)
                    _context.m_adm_assignlinkrolewise.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return entity.linkaccessid;
        }
      //  #endregion
    }
}
