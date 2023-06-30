using MediatR;
using SRIS.Application.Common.Interfaces.ISurveyPlan;
using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.EnumerationTeam.Command
{
   public class DeleteEanoTeamCommand : IRequest<CommonMobileApiStatus>
    {
        public int createdby { get; set; }
        public string action { get; set; }
        public int assigneaid { get; set; }
    }
    public class DeleteEanoTeamCommandHandler : IRequestHandler<DeleteEanoTeamCommand, CommonMobileApiStatus>
    {
        private readonly ISurveyPlanService _iSurveyPlanService;

        public DeleteEanoTeamCommandHandler(ISurveyPlanService iSurveyPlanService)
        {
            _iSurveyPlanService = iSurveyPlanService;
        }

        public async Task<CommonMobileApiStatus> Handle(DeleteEanoTeamCommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
            CommonMobileApiStatus obj = new CommonMobileApiStatus();

            try
            {

                retval = await _iSurveyPlanService.DeleteEnumerationTeam(request.assigneaid, request.createdby, request.action);
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
