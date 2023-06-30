/*
* File Name : UpdateRegisterMemberCommand.cs
* class Name : UpdateRegisterMemberCommand, UpdateRegisterMemberCommandHandler
* Created Date : 13th Aug 2021
* Created By : Spandana Ray
* Description : command class To update the grievance member
*/
using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;


namespace SRIS.Application.Grievances.Commands.RegisterMember
{
    public class UpdateRegisterMemberCommand : IRequest<int>
    {
        public int memberid { get; set; }
        public int comitteid { get; set; }
        public string commiteemembername { get; set; }
        public string fathername { get; set; }
        public int memberpositionid { get; set; }
        public string contactnumber { get; set; }
        public string email { get; set; }
        public int createdby { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
    }
    public class UpdateRegisterMemberCommandHandler : IRequestHandler<UpdateRegisterMemberCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateRegisterMemberCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        #region "To update the grievance member"
        ///<summary>
        /// Created By Spandana Ray on 13/08/2021
        /// </summary>
        /// <parameter>Request Object of UpdateRegisterMemberCommand</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To update the grievance member</remarks>
        public async Task<int> Handle(UpdateRegisterMemberCommand request, CancellationToken cancellationToken)
        {
            Regex rgx1 = new Regex("[^A-Za-z0-9 ]");
            var entity = await _context.m_grievance_registermember.FindAsync(request.memberid);

            if (entity == null)
            {
                throw new NotFoundException(nameof(SRIS.Domain.Entities.Grievance.RegisterMember), request.commiteemembername);
            }
            try
            {
                bool hasSpecialChars = rgx1.IsMatch(request.commiteemembername);
                bool hasSpecialChars1 = rgx1.IsMatch(request.fathername);
                if (_context.m_grievance_registermember.Where(r => r.memberid != request.memberid && r.comitteid == request.comitteid && r.commiteemembername == request.commiteemembername).Count() > 0)
                {
                    return 301;
                }
                   
                else if (_context.m_grievance_registermember.Where(r => r.memberid != request.memberid && r.contactnumber == request.contactnumber).Count() > 0)
                {
                    return 302;
                }
                   
                else if (_context.m_grievance_registermember.Where(r => r.memberid != request.memberid && r.email == request.email).Count() > 0)
                {
                    return 303;
                }
                else if (hasSpecialChars == true || hasSpecialChars1 == true)
                {
                    return 403;
                }
                else
                {
                    entity.regionid = request.regionid;
                    entity.districtid = request.districtid;
                    entity.wardid = request.wardid;
                    entity.settlementid = request.settlementid;

                    entity.comitteid = request.comitteid;
                    entity.commiteemembername = request.commiteemembername;
                    entity.fathername = request.fathername;
                    entity.memberpositionid = request.memberpositionid;
                    entity.contactnumber = request.contactnumber;
                    entity.email = request.email;
                    entity.updatedby = request.createdby;
                    await _context.SaveChangesAsync(cancellationToken);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return entity.memberid;
        }
        #endregion
    }
}
