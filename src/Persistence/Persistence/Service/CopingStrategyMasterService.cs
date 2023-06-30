using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.CopingStrategyMasters.Queries.GetCopingStrategyMaster;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Service
{
    public class CopingStrategyMasterService: BaseRepository, ICopingStrategyMasterService
    {
        private readonly IConnectionFactory _connectionFactory;
        public CopingStrategyMasterService(IConnectionFactory connectionFactory) : base(connectionFactory)//connectionFactory
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<CopingStrategyMasterDto>> GetCopingStartegyMaster(string action)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_master_copingStategy";
                    con.Open();
                    DynamicParameters objParam = new DynamicParameters();
                    objParam.Add("p_action", action);
                    objParam.Add("p_copingid", 0);
                    objParam.Add("p_copingname", "");
                    objParam.Add("p_description", "");
                    objParam.Add("p_copingtypeid", 0);
                    objParam.Add("p_createdby", 0);
                    objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                    var result = await con.QueryAsync<CopingStrategyMasterDto>(Query, objParam, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> AddCopingStartegyMaster(CopingStrategyMasterDto master)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", master.action);
                objParam.Add("p_copingid", master.copingid);
                objParam.Add("p_copingname", master.copingname);
                objParam.Add("p_description", master.description);
                objParam.Add("p_copingtypeid", master.copingtypeid);
                objParam.Add("p_createdby", master.createdby);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                var result = await Connection.ExecuteAsync("usp_master_copingStategy", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> UpdateCopingStartegyMaster(CopingStrategyMasterDto master)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", master.action);
                objParam.Add("p_copingid", master.copingid);
                objParam.Add("p_copingname", master.copingname);
                objParam.Add("p_description", master.description);
                objParam.Add("p_copingtypeid", master.copingtypeid);
                objParam.Add("p_createdby", master.createdby);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                var result = await Connection.ExecuteAsync("usp_master_copingStategy", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
