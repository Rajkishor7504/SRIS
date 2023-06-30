using MediatR;
using SRIS.Application.Common.Interfaces.ISurveyPlan;
using SRIS.Application.SurveyPlanning.EnumerationArea.Query;
using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.EnumerationTeam.Command
{
   public class CreateEanoTeamCommand : IRequest<CommonMobileApiStatus>
    {
        public int assigneaid { get; set; }
        public int createdby { get; set; }
        public int surveyplanid { get; set; }
        public string action { get; set; }
        public int teamid { get; set; }
        public int eaid { get; set; }
        public List<EnumerationTeamModel> settlementdata { get; set; }
        public List<EnumerationAreaModel> list { get; set; }
    }
    public class CreateEanoTeamCommandHandler : IRequestHandler<CreateEanoTeamCommand, CommonMobileApiStatus>
    {


        private readonly ISurveyPlanService _iSurveyPlanService;

        public CreateEanoTeamCommandHandler(ISurveyPlanService iSurveyPlanService)
        {
            _iSurveyPlanService = iSurveyPlanService;
        }

        public async Task<CommonMobileApiStatus> Handle(CreateEanoTeamCommand request, CancellationToken cancellationToken)
        {

            int retval = 0;
            CommonMobileApiStatus objEmpList = new CommonMobileApiStatus();
           
            try
            {
                var entity = new EnumerationTeamDto();
                entity.action = request.action;
                entity.surveyplanid = request.list[0].surveyplanid;
                entity.assigneaid = request.assigneaid;
                entity.eaid = request.list[0].eaid;
                entity.teamid = request.list[0].teamid;
                entity.createdby = request.createdby;
                entity.List = request.list;
                retval = await _iSurveyPlanService.AddEnumerationTeam(entity);
                objEmpList.status = retval.ToString();
                objEmpList.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);


            }
            catch (Exception ex)
            {
                objEmpList.status = "500";
                objEmpList.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objEmpList.errorMessage = ex.Message;
            }
            return objEmpList;

        }
    }
}
