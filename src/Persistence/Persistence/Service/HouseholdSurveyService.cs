
using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.Household.QASurvey.Query;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service
{
    public class HouseholdSurveyService : BaseRepository, IHouseholdSurveyService
    {
        private readonly IConnectionFactory _connectionFactory;
        public HouseholdSurveyService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        

        public async Task<int> UpdateOverallVerifiedStatusOfHousehold(OverallVerifiedStatusDto objRegisterhhdto)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objRegisterhhdto.action);
                objParam.Add("p_hhid", objRegisterhhdto.hhid);               
                objParam.Add("p_createdby", objRegisterhhdto.createdby);                
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_hhr_overallverified_ae", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> UpdateOverallApprovedStatusOfHousehold(OverallStatusDto obj)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", obj.action);
                objParam.Add("p_hhid", obj.hhid);
                objParam.Add("p_createdby", obj.createdby);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_hhr_overallapproved_ae", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
