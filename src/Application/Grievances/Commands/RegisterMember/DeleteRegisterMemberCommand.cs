/*
* File Name : CreateRegisterMemberCommand.cs
* class Name : CreateRegisterMemberCommand, CreateRegisterMemberCommandHandler
* Created Date : 13th Aug 2021
* Created By : Spandana Ray
* Description : command class to register the grievance member
*/
using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace SRIS.Application.Grievances.Commands.RegisterMember
{
    public class DeleteRegisterMemberCommand : IRequest<int>
    {
        public int memberid { get; set; }
        public int createdby { get; set; }
    }
    public class DeleteRegisterMemberCommandHandler : IRequestHandler<DeleteRegisterMemberCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteRegisterMemberCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        #region "To register the grievance member"
        ///<summary>
        /// Created By Spandana Ray on 13/08/2021
        /// </summary>
        /// <parameter>Request Object of DeleteRegisterMemberCommand</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To register the grievance member</remarks>
        public async Task<int> Handle(DeleteRegisterMemberCommand request, CancellationToken cancellationToken)
        {
            
            int count = 0;
            int countFwd = 0;
            int retval = 0;
            var entity = await _context.m_grievance_registermember.FindAsync(request.memberid);           
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(SRIS.Domain.Entities.Grievance.RegisterMember), request.memberid);
                }
                count = _context.t_grievance_registration.Where(x => x.createdby == entity.userid && !x.deletedflag).Count();
                countFwd = _context.t_grievance_forward.Where(x => (x.forwardedTo_committeeId == entity.comitteid || x.forwardedBy_userId == entity.userid)  && !x.deletedflag).Count();
                if (count > 0 || countFwd >0)
                {
                    retval = 402;
                }
                else
                {
                    entity.deletedflag = true;
                    entity.updatedby = request.createdby;
                    await _context.SaveChangesAsync(cancellationToken);
                    retval = 200;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return retval;
        }
        #endregion
    }
}
