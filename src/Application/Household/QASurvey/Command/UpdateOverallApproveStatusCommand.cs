using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.Household.QASurvey.Query;
using SRIS.Application.NotificationMasterItem.Queries.GetNotoficationMasterQueriesItem;
using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.QASurvey.Command
{
   public class UpdateOverallApproveStatusCommand : IRequest<CommonMobileApiStatus>
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int createdby { get; set; }
    }
    public class UpdateOverallApproveStatusHandler : IRequestHandler<UpdateOverallApproveStatusCommand, CommonMobileApiStatus>
    {
        private readonly IApplicationDbContext _context;
        private readonly IGrievanceService _igrievanceService;

        private readonly IHouseholdSurveyService _iHouseholdService;

        public UpdateOverallApproveStatusHandler(IHouseholdSurveyService iHouseholdService, IGrievanceService igrievanceService)
        {
            _iHouseholdService = iHouseholdService;
            _igrievanceService = igrievanceService;
        }

        public async Task<CommonMobileApiStatus> Handle(UpdateOverallApproveStatusCommand request, CancellationToken cancellationToken)
        {
            var entity1 = new NotificationMasterDto();
            CommonMobileApiStatus obj = new CommonMobileApiStatus();
            int retval = 0;
            try
            {
                if (request.hhid == 0)
                {
                    obj.status = "400";
                    obj.message = CommonHelper.GetEnumDescription((ResponseStatus)400);
                }
                else
                {
                    var entity = new OverallStatusDto();
                    entity.action = request.action;
                    entity.hhid = request.hhid;
                    entity.createdby = request.createdby;
                    retval = await _iHouseholdService.UpdateOverallApprovedStatusOfHousehold(entity);
                    obj.status = retval.ToString();
                    obj.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
                    if (retval == 200)
                    {
                        entity1.refNo = request.hhid;
                        entity1.ModuleName = "QA Supervisor";
                        entity1.CreatedBy = request.createdby;
                        await _igrievanceService.UpdateqasupervisorNotification(entity1);
                    }
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
