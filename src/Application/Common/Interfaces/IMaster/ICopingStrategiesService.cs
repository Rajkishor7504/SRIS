using SRIS.Application.AllMaster.CopingStrategiesHouseholdMasterAPI.Queries.GetCopingStrategies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IMaster
{
   public interface ICopingStrategiesService
    {
        Task<List<CommonCopingStrategiesTypeDto>> GetcopingStrategyData();
        Task<List<CommonCopingStrategiesDto>> GetrestoringData();
        Task<List<CommonfoodCopingStrategiesDto>> GetfoodrestoringData();
    }
}
