using SRIS.Application.AllMaster.DistanceMasterAPI.Queries.GetDistanceMaster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IMaster
{
   public interface IDistanceMasterService
    {
        Task<List<CommonDistanceMasterDto>> GettransportationmodeData();
        Task<List<CommonDistanceMasterDto>> GetserviceData();

    }
}
