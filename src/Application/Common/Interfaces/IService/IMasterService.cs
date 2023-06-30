using SRIS.Application.Masters.Queries.GetMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
   public interface IMasterService
    {
        Task<int> AddDemographyMaster(MasterDto Master);
        Task<List<MasterDto>> GetLevelDetails(string action,int parentid,int leveldtlsid);
        Task<int> DeleteDemography(int? id);
        DataTable GetQueryData(string strQuery);
        // Task<int> GetLevelDetails(MasterDto entity);
        Task<List<MasterDto>> GetLevelData(string action, int parentid, int leveldtlsid,int id);
    }
}
