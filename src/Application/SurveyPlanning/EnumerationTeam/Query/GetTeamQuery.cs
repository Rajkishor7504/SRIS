using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces.ISurveyPlan;
using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.EnumerationTeam.Query
{
   public class GetTeamQuery : IRequest<EnumerationTeamVM>
    {
        public string action { get; set; }
        public int planid { get; set; }
        public int assigneaid { get; set; }
        public int teamid { get; set; }
        public int searchid { get; set; }
    }

    public class GetTeamQueryHandler : IRequestHandler<GetTeamQuery, EnumerationTeamVM>
    {
        private readonly ISurveyPlanService _iSurveyPlanService;
        private readonly IMapper _mapper;

        public GetTeamQueryHandler(ISurveyPlanService iSurveyPlanService, IMapper mapper)
        {
            _iSurveyPlanService = iSurveyPlanService;
            _mapper = mapper;
        }

        public async Task<EnumerationTeamVM> Handle(GetTeamQuery request, CancellationToken cancellationToken)
        {
            EnumerationTeamVM objVM = new EnumerationTeamVM();

            try
            {
                objVM.status = "200";
                objVM.List = await _iSurveyPlanService.GetEnumerationTeam(request);
                objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)200);
            }

            catch (Exception ex)
            {
                objVM.status = "500";
                objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objVM.errorMessage = ex.Message;
            }
            return objVM;


        }

    }


}
