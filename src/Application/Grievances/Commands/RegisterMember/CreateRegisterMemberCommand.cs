/*
* File Name : CreateRegisterMemberCommand.cs
* class Name : CreateRegisterMemberCommand, CreateRegisterMemberCommandHandler
* Created Date : 13th Aug 2021
* Created By : Spandana Ray
* Description : command class to register the grievance member
*/
using MediatR;
using SRIS.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SRIS.Application.Grievances.Queries.GetRegisterMember;
using System.Text.RegularExpressions;

namespace SRIS.Application.Grievances.Commands.RegisterMember
{
    public class CreateRegisterMemberCommand : IRequest<int>
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
        public string password { get; set; }
        public string Secretkey { get; set; }
        public string rolename { get; set; }
    }
    public class CreateRegisterMemberCommandHandler : IRequestHandler<CreateRegisterMemberCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IGrievanceService _iGrievanceService;

        public CreateRegisterMemberCommandHandler(IApplicationDbContext context, IGrievanceService iGrievanceService)
        {
            _context = context;
            _iGrievanceService = iGrievanceService;
        }

        #region "To register the grievance member"
        ///<summary>
        /// Created By Spandana Ray on 13/08/2021
        /// </summary>
        /// <parameter>Request Object of CreateRegisterMemberCommand</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To register the grievance member</remarks>
        public async Task<int> Handle(CreateRegisterMemberCommand request, CancellationToken cancellationToken)
        {
            Regex rgx1 = new Regex("[^A-Za-z0-9 ]");
            var entity = new RegisterMemberDto();
            try
            {
                bool hasSpecialChars = rgx1.IsMatch(request.commiteemembername);
                bool hasSpecialChars1 = rgx1.IsMatch(request.fathername);
                if (_context.m_grievance_registermember.Where(r => r.comitteid == request.comitteid && r.commiteemembername == request.commiteemembername).Count() > 0)
                {                 
                    return 301;
                } 
                else if (_context.m_grievance_registermember.Where(r => r.contactnumber == request.contactnumber).Count() > 0)
                {
                    return 302;
                }
                    
                else if (_context.m_grievance_registermember.Where(r => r.email == request.email).Count() > 0)
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
                    entity.createdby = request.createdby;
                    entity.rolename = request.rolename;
                    entity.password = request.password;
                    entity.Secretkey = request.Secretkey;
                   return await _iGrievanceService.RegisterMember(entity);

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
