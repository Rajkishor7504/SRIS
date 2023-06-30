using SRIS.Application.SurveyPlanning.EnumerationArea.Command;
using SRIS.Application.SurveyPlanning.EnumerationArea.Query;
using SRIS.Application.SurveyPlanning.EnumerationTeam.Command;
using SRIS.Application.SurveyPlanning.EnumerationTeam.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.ISurveyPlan
{
   public interface ISurveyPlanService
    {
        public Task<int> CheckEano(string action,string eano,int eaid);
        Task<int> AddEnumerationArea(EanoAreaindoDto obj);
        Task<List<EnumerationAreaModel>> GetEnumerationArea(GetEanoArea obj);
        Task<int> DeleteEnumerationArea(int eaid, int createdby,string action);
      

        #region--------enumeration team tag--------
        Task<int> AddEnumerationTeam(EnumerationTeamDto obj);
        Task<List<EnumerationTeamInfo>> GetEnumerationTeam(GetTeamQuery obj);
        Task<int> DeleteEnumerationTeam(int assigneaid, int createdby, string action);
        #endregion
    }
}
