using SRIS.Application.Household.QASurvey.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IService
{
   public interface IHouseholdSurveyService
    {
        Task<int> UpdateOverallVerifiedStatusOfHousehold(OverallVerifiedStatusDto objRegisterhhdto);
        Task<int> UpdateOverallApprovedStatusOfHousehold(OverallStatusDto obj);
    }
}
