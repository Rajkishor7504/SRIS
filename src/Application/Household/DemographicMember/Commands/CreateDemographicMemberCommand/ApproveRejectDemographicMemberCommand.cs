using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.DemographicMember.Commands
{
    public class ApproveRejectDemographicMemberCommand: IRequest<DemographicMemberList>
    {
        public int memberid { get; set; }
        public int createdby { get; set; }
        public int hhid { get; set; }
        public string action { get; set; }
        public string Remark { get; set; }
        public int Gregid { get; set; }
    
    }
    public class ApproveRejectDemographicMemberCommandHandler : IRequestHandler<ApproveRejectDemographicMemberCommand, DemographicMemberList>
    {
        private readonly IHouseholdService _iHouseholdService;

        public ApproveRejectDemographicMemberCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<DemographicMemberList> Handle(ApproveRejectDemographicMemberCommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
            DemographicMemberList obj = new DemographicMemberList();

            try
            {

                retval = await _iHouseholdService.ApproveRejectDemographicMember(request.memberid, request.hhid, request.createdby, request.action,request.Remark, request.Gregid);
                obj.status = Convert.ToString(retval);
                obj.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);

            }
            catch (Exception ex)
            {
                obj.status = "500";
                obj.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                obj.errorMessage = ex.Message;
                throw new Exception(ex.Message);
            }
            return obj;
        }
    }
}
