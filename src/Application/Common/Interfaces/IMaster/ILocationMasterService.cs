using SRIS.Application.LocationMaster.Queries.GetLocationMaster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
  public  interface ILocationMasterService
    {
        Task<List<lgaDto>> GetLevelData();
        Task<List<DistrictDto>> GetDistrictData();
        Task<List<WardDto>> GetWardData();
        Task<List<SettlementDto>> GetSettlementData();     
    }

    public interface ILocationMasterServiceM
    {
        Task<List<lgaDto>> GetLevelData();
        Task<List<DistrictDto>> GetDistrictData();
        Task<List<WardDto>> GetWardData();
        Task<List<SettlementDto>> GetSettlementData();
    }

    public interface IEnumeratorLocationMasterServiceM
    {
        Task<List<lgaDto>> GetLevelData(int userid);
        Task<List<DistrictDto>> GetDistrictData(int userid);
        Task<List<WardDto>> GetWardData(int userid);
        Task<List<SettlementDto>> GetSettlementData(int userid);
        Task<List<ClusterNumber>> GetClusterNo(string action, int planid);
        Task<List<EnumerationSurveyPlan>> GetEnumerationData(string action,int userid);
        Task<List<EnumerationEAModel>> GetEnumerationEAData(string action, int userid);

       
    }
    public interface IEnumeratorLocationMasterServiceCM
    {
        Task<List<EnumerationSurveyPlan>> GetEnumerationData(string action, int userid);
        Task<List<ClusterNumber>> GetClusterNo(string action, int planid);
        Task<List<lgaDto>> GetClusterLevelData(int planid, int clno);
        Task<List<DistrictDto>> GetClusterDistrictData(int planid, int clno, int lga);
        Task<List<WardDto>> GetClusterWardData(int clno, int lga, int dis);
        Task<List<SettlementDto>> GetClusterSettlementData(int clno, int lga, int dis, int ward);
        Task<List<EnumerationEAModel>> GetEnumerationEAData(int clno, int lga, int dis, int ward, int settlement);
    }
}
