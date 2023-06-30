using Dapper;
using SRIS.Application.ClusterMaster.Queries.GetClusterMasterQueries;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Domain.Common;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Service
{
   public class ClusterMasterService: BaseRepository, IClusterMasterService
    {
        private readonly IConnectionFactory _connectionFactory;
        public ClusterMasterService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> AddClusterMaster(ClusterMasterDto ClusterMaster)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", ClusterMaster.action);
                objParam.Add("searchid", 0);
                objParam.Add("p_EaNo", ClusterMaster.eano);
                objParam.Add("p_ClusterNo", ClusterMaster.clusterno);
                objParam.Add("p_LgaNo", ClusterMaster.regionid);
                objParam.Add("p_DistrictNo", ClusterMaster.districtid);
                objParam.Add("p_WardNo", ClusterMaster.wardid);
                objParam.Add("p_SettlementNo", ClusterMaster.settlementid);
                objParam.Add("Createdby", ClusterMaster.createdby);
                objParam.Add("p_id", 0);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                var result =await Connection.ExecuteAsync("usp_cluster_master", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> UpdateClusterMaster(ClusterMasterDto ClusterMaster)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", ClusterMaster.action);
                objParam.Add("searchid", 0);
                objParam.Add("p_EaNo", ClusterMaster.eano);
                objParam.Add("p_ClusterNo", ClusterMaster.clusterno);
                objParam.Add("p_LgaNo", ClusterMaster.regionid);
                objParam.Add("p_DistrictNo", ClusterMaster.districtid);
                objParam.Add("p_WardNo", ClusterMaster.wardid);
                objParam.Add("p_SettlementNo", ClusterMaster.settlementid);
                objParam.Add("Createdby", ClusterMaster.createdby);
                objParam.Add("p_id", ClusterMaster.id);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                var result =await Connection.ExecuteAsync("usp_cluster_master", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> AddClusterMasterBulk(ClusterMasterDto ClusterMaster)
        {
            try
            {
                string excelxml = CommonHelper.SerializeToXMLString(ClusterMaster.Lists);
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_xml", excelxml);
                objParam.Add("p_Createdby", ClusterMaster.createdby);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                var result =await Connection.ExecuteAsync("usp_cluster_master_bulk", objParam, null, null, CommandType.StoredProcedure);
                return  objParam.Get<int>("p_out");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        async Task<List<ClusterMasterDto>> IClusterMasterService.GetLevelDetails(string action, int parentid, int id)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_cluster_master";
                    con.Open();
                    DynamicParameters objParam = new DynamicParameters();
                    objParam.Add("p_action", action);
                    objParam.Add("searchid", parentid);
                    objParam.Add("p_id", id);
                    objParam.Add("p_EaNo", 0);
                    objParam.Add("p_ClusterNo", 0);
                    objParam.Add("p_LgaNo", 0);
                    objParam.Add("p_DistrictNo", 0);
                    objParam.Add("p_WardNo", 0);
                    objParam.Add("p_SettlementNo", 0);
                    objParam.Add("Createdby",0);
                    objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                    var result = await con.QueryAsync<ClusterMasterDto>(Query, objParam, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
