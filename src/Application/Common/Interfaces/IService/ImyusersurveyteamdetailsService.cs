using SRIS.Application.My_UsersurveyTeamDetails.Query;
using SRIS.Application.SurveyPlanning.SurveyTeamMasterItem.Query.GetSurveyTeamMasterItem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
    public interface ImyusersurveyteamdetailsService
    {
        Task<List<My_usersurveyTeamdetailsDto>> Getmusurveydetails(My_usersurveyTeamdetailsDto myusteamdetails);
        Task<List<SurveyTeamMasterDto>> Getteamdetails(SurveyTeamMasterDto myusteamdetails);
        Task<int> CreateTeam(SurveyTeamMasterDto obj);
        Task<int> deleteTeam(int? teamid);

    }
}
