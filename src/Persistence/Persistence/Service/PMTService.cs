using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.PMT.PMTExecution.Queries.GetParameterItem;
using SRIS.Application.PMT.PMTExecution.Queries.GetPMTResult;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service
{
    public class PMTService : BaseRepository, IPMTService
    {
        private readonly IConnectionFactory _connectionFactory;
        public PMTService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<PMTCategoryWiseCountDto>> GetPMTCategoryWiseCount(string action, string locationid,  int surveyid, int pmtconfigureid)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_pmt_result";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", action);
                    param.Add("p_locationid", locationid);
                    param.Add("p_surveyid", surveyid);
                    param.Add("p_pmtconfigureid", pmtconfigureid);
                    param.Add("p_resultid", 0);
                    var result = await con.QueryAsync<PMTCategoryWiseCountDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
               throw new Exception(ex.Message);
            }
        }
        public async Task<List<PMTReportWiseCountDto>> GetPMTReport(string action, string locationid, int surveyid, int pmtconfigureid)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_pmt_result";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", action);
                    param.Add("p_locationid", locationid);
                    param.Add("p_surveyid", surveyid);
                    param.Add("p_pmtconfigureid", pmtconfigureid);
                    param.Add("p_resultid", 0);
                    var result = await con.QueryAsync<PMTReportWiseCountDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<PMTResultDto>> GetPMTResult(string action, string locationid, int surveyid, int pmtconfigureid)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_pmt_result";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", action);
                    param.Add("p_locationid", locationid);
                    param.Add("p_surveyid", surveyid);
                    param.Add("p_pmtconfigureid", pmtconfigureid);
                    param.Add("p_resultid", 0);
                    var result = await con.QueryAsync<PMTResultDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<PMTResultParameterDto>> GetParameterWisePMTResult(int resultid)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_pmt_result";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", "PMR");
                    param.Add("p_locationid", 0);
                    param.Add("p_surveyid", 0);
                    param.Add("p_pmtconfigureid", 0);
                    param.Add("p_resultid", resultid);                   
                    var result = await con.QueryAsync<PMTResultParameterDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> PMTExecution(ParameterDto objPMT)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_pmtconfigureid", objPMT.pmtconfigureid);
                objParam.Add("p_locationid", objPMT.locationid);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_pmt_execution", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
