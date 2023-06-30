using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.SurveyPlanning.PlanSurvey.Queries.GetPlanSurvey;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SRIS.Domain.Common;

namespace SRIS.Application.SurveyPlanningMobile.GetSurveyPlan.GetQuery
{
   public class GetSurveyQuery : IRequest<SurveyPlanVM>
    {
        
    }
    public class GetSurveyQueryMobileHandler : IRequestHandler<GetSurveyQuery, SurveyPlanVM>
    {
        private readonly IPlanSurveyService _iIPlanSurveyService;
        private readonly IMapper _mapper;

        public GetSurveyQueryMobileHandler(IPlanSurveyService iPlanSurveyService, IMapper mapper)
        {
            _iIPlanSurveyService = iPlanSurveyService;
            _mapper = mapper;
        }

        public async Task<SurveyPlanVM> Handle(GetSurveyQuery request, CancellationToken cancellationToken)
        {
            SurveyPlanVM model = new SurveyPlanVM();
            try
            {
                var entity = new SurveyPlanningDto();
                entity.action = "p";
                var entitylocation = new SurveyPlanningDto();
                entitylocation.action = "l";
                var plan = await _iIPlanSurveyService.GetPlanSurvey(entity);
                var location = await _iIPlanSurveyService.GetPlanSurvey(entitylocation);
                var list = (from a in plan
                    select new SurveyPlanDto
                    {
                        serveyId = a.planid,
                        surveyName = a.surveyname != null ? a.surveyname : "",
                        extendedDate = a.extendeddate != null ? a.extendeddate : "",
                        description = a.description != null ? a.description : "",
                        startDate = a.startdate != null ? a.startdate : "",
                        endDate = a.enddate != null ? a.enddate : "",
                        regionId = location.Where(e => e.planid == a.planid).FirstOrDefault()!=null?location.Where(e=>e.planid==a.planid).FirstOrDefault().levelid:0,
                        regionName = location.Where(e => e.planid == a.planid).FirstOrDefault()!=null?location.Where(e => e.planid == a.planid).FirstOrDefault().region:"",
                        district = (from b in location.Where(c => c.planid == a.planid).ToList()
                                    select new DistrictDto
                                    {
                                        name = b.dist,
                                        id = b.locationid,
                                        regionId = b.levelid,
                                    }
                                    ).ToList()

                    }).ToList();
             
                model.serveyPlan = list;
                model.status = MobileApiStatusCode.OK;
                model.message = "Ok";
                model.errorMessage = "";
            }
            catch(Exception ex)
            {
                model.serveyPlan = null;
                model.status = MobileApiStatusCode.Badrequest;
                model.message = "Badrequest";
                model.errorMessage = ex.Message;
            }
            return model;
        }
    }
}
