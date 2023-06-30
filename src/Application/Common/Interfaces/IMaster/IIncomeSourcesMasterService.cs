using SRIS.Application.AllMaster.IncomeSourceAPI.Queries.GetIncomeSourceAllMaster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IMaster
{
   public interface IIncomeSourcesMasterService
    {
        Task<List<CommonIncomeSourceDto>> GetmainIncomeSourceData();
        Task<List<CommonIncomeSourceDto>> GetsecondIncomeSourceData();
        Task<List<CommonIncomeSourceDto>> GetaidTypeData();
        Task<List<CommonIncomeSourceDto>> GetaidFrequencyData();
        Task<List<CommonIncomeSourceDto>> GetorgTypeData();
    }
}
