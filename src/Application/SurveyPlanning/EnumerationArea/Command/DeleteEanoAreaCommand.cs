using MediatR;
using SRIS.Application.Common.Interfaces.ISurveyPlan;
using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.EnumerationArea.Command
{
   public class DeleteEanoAreaCommand: IRequest<CommonMobileApiStatus>
    {
        public int createdby { get; set; }
        public string action { get; set; }
        public int eaid { get; set; }
    }
    public class DeleteEanoAreaCommandHandler : IRequestHandler<DeleteEanoAreaCommand, CommonMobileApiStatus>
    {
        private readonly ISurveyPlanService _iSurveyPlanService;

        public DeleteEanoAreaCommandHandler(ISurveyPlanService iSurveyPlanService)
        {
            _iSurveyPlanService = iSurveyPlanService;
        }

        public async Task<CommonMobileApiStatus> Handle(DeleteEanoAreaCommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
            CommonMobileApiStatus obj = new CommonMobileApiStatus();

            try
            {

                retval = await _iSurveyPlanService.DeleteEnumerationArea(request.eaid, request.createdby,request.action);
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
