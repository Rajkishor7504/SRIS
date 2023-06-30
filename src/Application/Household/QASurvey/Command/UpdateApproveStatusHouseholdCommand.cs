using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Household.QASurvey.Query;
using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.QASurvey.Command
{
    public class UpdateApproveStatusHouseholdCommand : IRequest<CommonMobileApiStatus>
    {
        public string action { get; set; }
        public string remarks { get; set; }
        public int moduleid { get; set; }
        public int hhid { get; set; }
        public int createdby { get; set; }
        public int approvestatus { get; set; }
    }
    public class UpdateApproveStatusHouseholdHandler : IRequestHandler<UpdateApproveStatusHouseholdCommand, CommonMobileApiStatus>
    {
     

        private readonly IHouseholdService _iHouseholdService;

        public UpdateApproveStatusHouseholdHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<CommonMobileApiStatus> Handle(UpdateApproveStatusHouseholdCommand request, CancellationToken cancellationToken)
        {
            CommonMobileApiStatus obj = new CommonMobileApiStatus();
            int retval = 0;
            try
            {
                if (request.hhid == 0 && request.moduleid == 0)
                {
                    obj.status = "400";
                    obj.message = CommonHelper.GetEnumDescription((ResponseStatus)400);
                }
                else
                {
                    var entity = new SurveyApproveStatusDto();
                    entity.action = request.action;
                    entity.hhid = request.hhid;
                    entity.moduleid = request.moduleid;                  
                    entity.approvestatus = request.approvestatus;
                    entity.remarks = request.remarks;
                    entity.createdby = request.createdby;
                    retval = await _iHouseholdService.UpdateApproveStatusOfHousehold(entity);
                    obj.status = retval.ToString();
                    obj.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
                }
            }
            catch (Exception ex)
            {
                obj.status = "500";
                obj.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
            }
            return obj;

        }
    }
}
