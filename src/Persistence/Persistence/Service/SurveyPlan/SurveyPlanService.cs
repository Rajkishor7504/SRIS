using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.ISurveyPlan;
using SRIS.Application.SurveyPlanning.EnumerationArea.Command;
using SRIS.Application.SurveyPlanning.EnumerationArea.Query;
using SRIS.Application.SurveyPlanning.EnumerationTeam.Command;
using SRIS.Application.SurveyPlanning.EnumerationTeam.Query;
using SRIS.Domain.Common;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Service.SurveyPlan
{
    public class SurveyPlanService : BaseRepository, ISurveyPlanService
    {
        private readonly IConnectionFactory _connectionFactory;
        public SurveyPlanService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddEnumerationArea(EanoAreaindoDto obj)
        {
            try
            {
                //string locationxml = CommonHelper.SerializeToXMLString(obj.locationdata);
              
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", obj.action);
                objParam.Add("p_eaid", obj.eaid);
                objParam.Add("p_eumdetlid", obj.enumdetlid);
                objParam.Add("p_surveyplanid", obj.surveyplanid);
                objParam.Add("p_clusterno", obj.clusterno);
                objParam.Add("p_regionid", obj.regionid);
                objParam.Add("p_distid", obj.distid);
                objParam.Add("p_wardid", obj.wardid);
                objParam.Add("p_settlementid", obj.settlementid);
                objParam.Add("p_eano", obj.eano);
                objParam.Add("p_createdby", obj.createdby);
                objParam.Add("p_locationxml", "");
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_survey_eanoarea_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       

        public async Task<int> CheckEano(string action, string eano,int eaid)
        {
          
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", action);
                objParam.Add("p_eano", eano);
            objParam.Add("p_eaid", eaid);
            objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
            await Connection.ExecuteAsync("usp_survey_eano_check", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");
           
        }

        public async Task<int> DeleteEnumerationArea(int eaid, int createdby,string action)
        {
            try
            {

                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", action);
                objParam.Add("p_eaid", eaid);
                objParam.Add("p_surveyplanid",0);
                objParam.Add("p_clusterno", 0);
                objParam.Add("p_regionid", 0);
                objParam.Add("p_distid", 0);
                objParam.Add("p_wardid", 0);
                objParam.Add("p_settlementid", 0);
                objParam.Add("p_eano", "");
                objParam.Add("p_createdby", createdby);
                objParam.Add("p_eumdetlid", 0);
                objParam.Add("p_locationxml", "");
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_survey_eanoarea_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<EnumerationAreaModel>> GetEnumerationArea(GetEanoArea obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_survey_eanoarea_ve";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", obj.action);
                    param.Add("p_eaid", obj.eaid);
                    param.Add("p_planid", obj.planid);
                    param.Add("p_searchid", obj.searchid);
                    var result = await con.QueryAsync<EnumerationAreaModel>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region
        public async Task<int> AddEnumerationTeam(EnumerationTeamDto obj)
        {
            try
            {
                string settlementxml = CommonHelper.SerializeToXMLString(obj.List);

                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", obj.action);
                objParam.Add("p_assigneaid", obj.assigneaid);
                objParam.Add("p_teamid", obj.teamid);
                objParam.Add("p_surveyplanid", obj.surveyplanid);
                objParam.Add("p_eano", obj.eaid);
                objParam.Add("p_createdby", obj.createdby);
                objParam.Add("p_settlementxml", settlementxml);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_survey_eanoteam_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<EnumerationTeamInfo>> GetEnumerationTeam(GetTeamQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_survey_eanoteam_ve";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", obj.action);
                    param.Add("p_planid", obj.planid);
                    param.Add("p_searchid", obj.searchid);
                    param.Add("p_assigneaid", obj.assigneaid);
                    param.Add("p_teamid", obj.teamid);
                    
                    var result = await con.QueryAsync<EnumerationTeamInfo>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteEnumerationTeam(int assigneaid, int createdby, string action)
        {
            try
            {

                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", action);
                objParam.Add("p_assigneaid", assigneaid);
                objParam.Add("p_teamid",0);
                objParam.Add("p_surveyplanid",0);
                objParam.Add("p_eano", 0);
                objParam.Add("p_createdby", createdby);
                objParam.Add("p_settlementxml", "");
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_survey_eanoteam_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
