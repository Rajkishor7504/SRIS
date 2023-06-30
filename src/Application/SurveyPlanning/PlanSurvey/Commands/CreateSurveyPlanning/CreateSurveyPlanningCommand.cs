using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.SurveyPlanning.PlanSurvey.Queries.GetPlanSurvey;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.PlanSurvey.Commands.CreateSurveyPlanning
{
    public class CreateSurveyPlanningCommand : IRequest<int>
    {
        public string action { get; set; }
        public DateTime surveystartdate { get; set; }
        public DateTime surveyenddate { get; set; }
        public int createdby { get; set; }
        public DateTime surveyextendeddate { get; set; }
        public string description { get; set; }
        public string surveyname { get; set; }
        public int planid { get; set; }

        public int locationid { get; set; }
        public int levelid { get; set; }
        public List<SurveyPlanningDto> Lists { get; set; }
        public int planlocationid { get; set; }
        public int clusterno { get; set; }
        public int regionid { get; set; }
    }
    public class CreateSurveyPlanningCommandHandler : IRequestHandler<CreateSurveyPlanningCommand, int>
    {
        private readonly IPlanSurveyService _iPlanSurveyService;

        public CreateSurveyPlanningCommandHandler(IPlanSurveyService iPlanSurveyService)
        {
            _iPlanSurveyService = iPlanSurveyService;
        }

        public async Task<int> Handle(CreateSurveyPlanningCommand request, CancellationToken cancellationToken)
        {
            Regex rgx1 = new Regex("[^A-Za-z0-9 ]");
            int retval = 0;
            var entity = new SurveyPlanningDto();
            try
            {

            
            
                if (request.action == "r" || request.action == "a")
                {
                    entity.action = request.action;
                if (request.action == "a")
                {
                    entity.planid = request.planid;
                }
                    entity.clusterno = request.clusterno;
                    entity.regionid = request.regionid;
                    entity.locationid = request.locationid;
                    entity.levelid = request.levelid;
                    entity.planlocationid = request.planlocationid;
                    entity.createdby = request.createdby;
                    //entity.Lists = request.Lists;
                    retval = await _iPlanSurveyService.AddLocation(entity);
                }
                else
                {
                    entity.action = request.action;
                    entity.surveystartdate = request.surveystartdate;
                    entity.surveyenddate = request.surveyenddate;
                    entity.createdby = request.createdby;
                    entity.surveyextendeddate = request.surveyextendeddate;
                    if (entity.surveyextendeddate.Date >= DateTime.Now.Date)
                    {
                        entity.statusid = 1;
                    }
                    entity.description = request.description;
                    entity.surveyname = request.surveyname;
                    entity.planid = request.planid;
                    if (entity.surveyname != null)
                    {
                        bool hasSpecialChars1 = rgx1.IsMatch(entity.surveyname);
                        if (hasSpecialChars1 == false && entity.action != "d")
                        {
                            retval = await _iPlanSurveyService.AddPlanSurvey(entity);
                        }
                        else
                        {
                            retval = 403;
                        }
                    }
                    else
                    {
                        retval = await _iPlanSurveyService.AddPlanSurvey(entity);
                    }
                }
            return retval;
            }
            catch(Exception ex)
            {
                throw ex;
            }






        }
    }
}
