using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.SurveyPlanning.SettlementWiseTargetMaster.Queries.GetSettlementWiseTargetMasterQuery;
using SRIS.Domain.Common;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service.SurveyPlan
{
    public class Settlementwisetargetservice : BaseRepository, ISettlementwisetargetservice
    {
        private readonly IConnectionFactory _connectionFactory;
        public Settlementwisetargetservice(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        async Task<List<SettlementWiseTargetDto>> ISettlementwisetargetservice.Geteanumber(SettlementWiseTargetDto eano)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_survey_getsetlmenttarget";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", eano.action);
                    param.Add("p_searchid", eano.searchid);
                    param.Add("p_planid", eano.planid);
                    param.Add("p_clusterno", eano.clusterno);
                    param.Add("p_rid", eano.regionid);
                    param.Add("p_did", eano.districtid);
                    param.Add("p_eaid", eano.eaid);
                    var result = await con.QueryAsync<SettlementWiseTargetDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async  Task<int> Createsettlementwisetarget(SettlementWiseTargetDto obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string settlementwisetargetxml = CommonHelper.SerializeToXMLString(obj.Lists);
                    DynamicParameters objParam = new DynamicParameters();
                    objParam.Add("p_action", obj.action);
                    objParam.Add("p_updatedby", "0");
                    objParam.Add("p_createdby", obj.createdby);
                    objParam.Add("p_settlementxml", settlementwisetargetxml);
                    objParam.Add("p_output", "", DbType.Int32, ParameterDirection.Output, 8);
                    await Connection.ExecuteAsync("usp_survey_settlementwisetarget_add", objParam, null, null, CommandType.StoredProcedure);
                    return objParam.Get<int>("p_output");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public async Task<int> Updatesettlementwisetarget(SettlementWiseTargetDto obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string settlementwisetargetxml = CommonHelper.SerializeToXMLString(obj.Lists);
                    DynamicParameters objParam = new DynamicParameters();
                    objParam.Add("p_action", obj.action);
                    objParam.Add("p_createdby", obj.createdby);
                    objParam.Add("p_updatedby", "1");
                    objParam.Add("p_settlementxml", settlementwisetargetxml);
                    objParam.Add("p_output", "", DbType.Int32, ParameterDirection.Output, 8);
                   await Connection.ExecuteAsync("usp_survey_settlementwisetarget_add", objParam, null, null, CommandType.StoredProcedure);
                    return objParam.Get<int>("p_output");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
