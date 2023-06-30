using SRIS.Application.AllMaster.HealthMaster.Queries.GetHealthAllMaster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
  public  interface IHealthMasterService
    {
        Task<List<CommonHealthMasterDto>> GetDiseaseData();
        Task<List<CommonHealthMasterDto>> GetSeeingDefficultyData();

        //Newly Adeed

        Task<List<CommonHealthMasterDto>> GetCommunicatingDefficultyData();
        Task<List<CommonHealthMasterDto>> GetSelfCareDefficultyData();
        Task<List<CommonHealthMasterDto>> GetWalkingDefficultyData();
        Task<List<CommonHealthMasterDto>> GetHearingDefficultyData();
        Task<List<CommonHealthMasterDto>> GetRememberingDefficultyData();
    }
}
