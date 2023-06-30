using SRIS.Application.SurveyPlanning.PlanSurvey.Queries.GetPlanSurvey;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
 public interface IPlanSurveyService
    {
        Task<int> AddPlanSurvey(SurveyPlanningDto SurveyPlanning);
        Task<List<SurveyPlanningDto>> GetPlanSurvey(SurveyPlanningDto SurveyPlanning);

        Task<int> AddLocationsSurvey(IList<SurveyPlanningDto> Locationlist);
        Task<int> AddLocation(SurveyPlanningDto SurveyPlanning);

        Task<int> UpdateSurveyStatus(SurveyPlanningDto SurveyPlanning);
    }
}



