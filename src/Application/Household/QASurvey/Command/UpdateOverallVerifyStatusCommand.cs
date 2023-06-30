using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.Household.QASurvey.Query;
using SRIS.Application.NotificationMasterItem.Queries.GetNotoficationMasterQueriesItem;
using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.QASurvey.Command
{
    public class UpdateOverallVerifyStatusCommand : IRequest<CommonMobileApiStatus>
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int createdby { get; set; }
      
    }
    public class UpdateOverallVerifyStatusHandler : IRequestHandler<UpdateOverallVerifyStatusCommand, CommonMobileApiStatus>
    {
        private readonly IApplicationDbContext _context;


        private readonly IHouseholdSurveyService _iHouseholdService;
        private readonly IGrievanceService _igrievanceService;
        public UpdateOverallVerifyStatusHandler(IHouseholdSurveyService iHouseholdService, IGrievanceService igrievanceService)
        {
            _iHouseholdService = iHouseholdService;
            _igrievanceService = igrievanceService;
        }

        public async Task<CommonMobileApiStatus> Handle(UpdateOverallVerifyStatusCommand request, CancellationToken cancellationToken)
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
                    var entity = new OverallVerifiedStatusDto();
                    entity.action = request.action;
                    entity.hhid = request.hhid;
                    entity.createdby = request.createdby;
                    retval = await _iHouseholdService.UpdateOverallVerifiedStatusOfHousehold(entity);
                    obj.status = retval.ToString();
                    obj.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
                    if (retval == 200)
                    {
                        entity1.refNo = request.hhid;
                        entity1.CreatedBy = request.createdby;
                        entity1.ModuleName = "QA Officer";
                        entity1.Information = "The Quality Officer verify the Household Number: " + null + " , pending for approval";
                        entity1.DestinationURL = "/Household/QASurvey/VerifiedSurveyDetails";
                        await _igrievanceService.UpdateQAOfficerNotification(entity1);
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
