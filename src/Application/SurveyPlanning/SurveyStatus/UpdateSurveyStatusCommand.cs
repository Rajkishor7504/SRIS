using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.SurveyPlanning.PlanSurvey.Queries.GetPlanSurvey;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.SurveyStatus
{
   public class UpdateSurveyStatusCommand : IRequest<int>
    {
        public string action { get; set; }
        public int statusid { get; set; }
        public int planid { get; set; }
        public int locationid { get; set; }
        public int levelid { get; set; }
        public string status { get; set; }
        public int createdby { get; set; }
    
    }
    public class UpdateSurveyStatusCommandHandler : IRequestHandler<UpdateSurveyStatusCommand, int>
    {
        private readonly IPlanSurveyService _iPlanSurveyService;

        public UpdateSurveyStatusCommandHandler(IPlanSurveyService iPlanSurveyService)
        {
            _iPlanSurveyService = iPlanSurveyService;
        }
        public async Task<int> Handle(UpdateSurveyStatusCommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
            var entity = new SurveyPlanningDto();
           
                entity.action = request.action;
                entity.statusid = request.statusid;
                entity.planid = request.planid;
                entity.status = request.status;
                entity.createdby = request.createdby;
                retval = await _iPlanSurveyService.UpdateSurveyStatus(entity);
            return retval;

        }

    }
}
