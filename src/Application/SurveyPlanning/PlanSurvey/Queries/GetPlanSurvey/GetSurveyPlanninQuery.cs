using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.PlanSurvey.Queries.GetPlanSurvey
{
   public class GetSurveyPlanninQuery : IRequest<SurveyPlanningVM>
    {
        public string action { get; set; }
        public int searchid { get; set; }
    }
    public class GetSurveyPlanninQueryHandler : IRequestHandler<GetSurveyPlanninQuery, SurveyPlanningVM>
    {
        private readonly IPlanSurveyService _iIPlanSurveyService;
        private readonly IMapper _mapper;

        public GetSurveyPlanninQueryHandler(IPlanSurveyService iPlanSurveyService, IMapper mapper)
        {
            _iIPlanSurveyService = iPlanSurveyService;
            _mapper = mapper;
        }

        public async Task<SurveyPlanningVM> Handle(GetSurveyPlanninQuery request, CancellationToken cancellationToken)
        {
            var entity = new SurveyPlanningDto();
            entity.action = request.action;
            entity.searchid = request.searchid;
            return new SurveyPlanningVM
            {
                Lists = await _iIPlanSurveyService.GetPlanSurvey(entity)
            };
        }
    }
}
