using SRIS.Application.CopingStrategyMasters.Queries.GetCopingStrategyMaster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IService
{
    public interface ICopingStrategyMasterService
    {
        Task<List<CopingStrategyMasterDto>> GetCopingStartegyMaster(string action);
        Task<int> AddCopingStartegyMaster(CopingStrategyMasterDto Master);
        Task<int> UpdateCopingStartegyMaster(CopingStrategyMasterDto Master);
    }
}
