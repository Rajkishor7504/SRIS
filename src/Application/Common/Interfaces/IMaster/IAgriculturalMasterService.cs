using SRIS.Application.AllMaster.AgriculturalMasterAPI.Queries.GetAgricultureMaster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IMaster
{
   public interface IAgriculturalMasterService
    {
        Task<List<CommonAgricultureMasterDto>> GetlivestockData();
        Task<List<CommonAgricultureMasterDto>> GetCropData();
        Task<List<CommonAgricultureMasterDto>> GetBreedingData();
        //22-03-23
        Task<List<CommonAgricultureMasterDto>> GetEcologyData();
    }
}
