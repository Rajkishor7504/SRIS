using SRIS.Application.ClusterMaster.Queries.GetClusterMasterQueries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IService
{
  public  interface IClusterMasterService
    {
        Task<int> AddClusterMaster(ClusterMasterDto Master);
        Task<int> AddClusterMasterBulk(ClusterMasterDto Master);
        Task<int> UpdateClusterMaster(ClusterMasterDto Master);
        Task<List<ClusterMasterDto>> GetLevelDetails(string action, int parentid, int leveldtlsid);
    }
}
