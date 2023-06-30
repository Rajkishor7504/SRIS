using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Masters.Queries.GetMaster;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service
{
    public class MasterService : BaseRepository, IMasterService
    {
        private readonly IConnectionFactory _connectionFactory;
        public MasterService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> AddDemographyMaster(MasterDto Master)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("paction", Master.action);
                objParam.Add("plevelname", Master.levelname);
                objParam.Add("plevelid", Master.levelid);
                objParam.Add("pparentid", Master.parentid);
                objParam.Add("pdescription", Master.description);
                objParam.Add("pcreatedby", 1);
                objParam.Add("pleveldetailid", Master.leveldetailid);
                objParam.Add("pcode", Master.code);
                objParam.Add("poutput", "", DbType.Int32, ParameterDirection.Output, 8);
              var result=Connection.ExecuteAsync("usp_demography_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("poutput");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        async Task<List<MasterDto>> IMasterService.GetLevelDetails(string action,int parentid,int leveldtlsid)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_fill_dropdown";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("action", action);
                    param.Add("searchid", parentid);
                    param.Add("leveldtlsid", leveldtlsid);
                    var result = await con.QueryAsync<MasterDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        Task<int> IMasterService.DeleteDemography(int? id)
        {
            throw new NotImplementedException();
        }
        public DataTable GetQueryData(string strQuery)
        {
            DataTable dt = new DataTable();
            dt.Load(Connection.ExecuteReader(strQuery));
            return dt;
        }

        public async Task<List<MasterDto>> GetLevelData(string action, int parentid, int leveldtlsid, int id)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_survey_fill_dropdown";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("action", action);
                    param.Add("searchid", parentid);
                    param.Add("leveldtlsid", leveldtlsid);
                    param.Add("id", id);
                    var result = await con.QueryAsync<MasterDto>(Query, param, commandType: CommandType.StoredProcedure);
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
