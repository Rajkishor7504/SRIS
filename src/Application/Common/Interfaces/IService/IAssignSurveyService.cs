using SRIS.Application.SurveyPlanning.AssignSurvey.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
   public interface IAssignSurveyService
    {
        Task<int> AddAssignSurvey(AssignSurveyDto assignSurvey);
        Task<int> AddAssignSurveyList(IList<AssignSurveyDto> assignSurvey);
        Task<List<AssignSurveyDto>> GetAssignedSurvey(AssignSurveyDto assignSurvey);


    }
}
