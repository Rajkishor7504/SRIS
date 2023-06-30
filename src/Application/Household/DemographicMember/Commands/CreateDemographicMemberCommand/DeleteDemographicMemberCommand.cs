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
    public class DeleteDemographicMemberCommand:IRequest<DemographicMemberList>
    {
        public int memberid { get; set; }
        public int createdby { get; set; }
        public int hhid { get; set; }
        public string action { get; set; }
    }
    public class DeleteConfigureCommiteeCommandHandler : IRequestHandler<DeleteDemographicMemberCommand, DemographicMemberList>
    {
        private readonly IHouseholdService _iHouseholdService;

        public DeleteConfigureCommiteeCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<DemographicMemberList> Handle(DeleteDemographicMemberCommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
            DemographicMemberList obj = new DemographicMemberList();
           
            try
            {

                retval = await _iHouseholdService.DeleteDemographicMember(request.memberid, request.hhid, request.createdby, request.action);
                obj.status = Convert.ToString(retval);
                obj.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);

            }
            catch (Exception ex)
            {
                obj.status = "500";
                obj.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                obj.errorMessage = ex.Message;
            }
            return obj;
        }
    }
}
