using SRIS.Application.AllMaster.ImpactOfShocksMasterAPI.Queries.GetImpactOfShocks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IMaster
{
   public interface IImpactOfShocksService
    {
        Task<List<CommonImpactOfShocksDto>> GetlivelihoodData();
        Task<List<CommonImpactOfShocksDto>> GetShocksData();
        Task<List<CommonImpactOfShocksDto>> GetSeverityTypeData();

    }
}
