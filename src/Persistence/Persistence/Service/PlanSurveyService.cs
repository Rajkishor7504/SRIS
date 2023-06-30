using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.SurveyPlanning.PlanSurvey.Queries.GetPlanSurvey;
using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service
{
   public class PlanSurveyService : BaseRepository, IPlanSurveyService
    {
        private readonly IConnectionFactory _connectionFactory;
        public PlanSurveyService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> AddPlanSurvey(SurveyPlanningDto SurveyPlanning)
        {
            try
            {

            
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_action", SurveyPlanning.action);
            objParam.Add("p_planid", SurveyPlanning.planid);
            objParam.Add("p_surveystartdate", SurveyPlanning.surveystartdate);
            objParam.Add("p_surveyenddate", SurveyPlanning.surveyenddate);
            objParam.Add("p_createdby", SurveyPlanning.createdby);
            objParam.Add("p_description", SurveyPlanning.description);
            objParam.Add("p_surveyextendeddate", SurveyPlanning.surveyextendeddate);
            objParam.Add("p_surveyname", SurveyPlanning.surveyname);
            objParam.Add("p_status", SurveyPlanning.statusid); 
            objParam.Add("p_output", "", DbType.Int32, ParameterDirection.Output, 8);
            await Connection.ExecuteAsync("usp_plansurvey_aed", objParam, null, null, CommandType.StoredProcedure);
           // return await result;
            return objParam.Get<int>("p_output");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        async Task<List<SurveyPlanningDto>> IPlanSurveyService.GetPlanSurvey(SurveyPlanningDto SurveyPlanning)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_getplansurvey";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", SurveyPlanning.action);
                    param.Add("p_searchid", SurveyPlanning.searchid);
                    var result = await con.QueryAsync<SurveyPlanningDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> AddLocation(SurveyPlanningDto SurveyPlanning)
        {
            try
            {


               // string Locationxml = CommonHelper.SerializeToXMLString(SurveyPlanning.Lists);

                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", SurveyPlanning.action);
                objParam.Add("p_planid", SurveyPlanning.planid);
                objParam.Add("p_clusterno", SurveyPlanning.clusterno);
                objParam.Add("p_regionid", SurveyPlanning.regionid);
                objParam.Add("p_locationid", SurveyPlanning.locationid);
                objParam.Add("p_levelid", SurveyPlanning.levelid);
                objParam.Add("p_createdby", SurveyPlanning.createdby);
                objParam.Add("p_planlocationid", SurveyPlanning.planlocationid);
                objParam.Add("p_Locationxml", "");
                objParam.Add("p_output", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_locationsurvey_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_output");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public async Task<int> AddLocation(SurveyPlanningDto SurveyPlanning)
        //{
        //    try
        //    {


        //    string Locationxml = CommonHelper.SerializeToXMLString(SurveyPlanning.Lists);

        //    DynamicParameters objParam = new DynamicParameters();
        //    objParam.Add("p_action", SurveyPlanning.action);
        //    objParam.Add("p_planid", SurveyPlanning.planid);
        //    objParam.Add("p_locationid", SurveyPlanning.locationid);
        //    objParam.Add("p_levelid", SurveyPlanning.levelid);
        //    objParam.Add("p_createdby", SurveyPlanning.createdby);
        //    objParam.Add("p_planlocationid", SurveyPlanning.planlocationid);
        //    objParam.Add("p_Locationxml", Locationxml);
        //    objParam.Add("p_output", "", DbType.Int32, ParameterDirection.Output, 8);
        //    await Connection.ExecuteAsync("usp_locationsurvey_aed", objParam, null, null, CommandType.StoredProcedure);
        //    return objParam.Get<int>("p_output");
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public async Task<int> AddLocationsSurvey(IList<SurveyPlanningDto> Locationlist)
        {
            int result = 0;
            foreach (var location in Locationlist)
            {
                result += await AddLocation(location);
            }
            return result;
        }
        public async Task<int> UpdateSurveyStatus(SurveyPlanningDto SurveyPlanning)
        {
            try
            {

            
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_action", SurveyPlanning.action);
            objParam.Add("p_statusid", SurveyPlanning.statusid);
            objParam.Add("p_assignmentid", SurveyPlanning.planid);
            objParam.Add("p_createdby", SurveyPlanning.createdby);
            objParam.Add("p_status", SurveyPlanning.status);
            objParam.Add("p_output", "", DbType.Int32, ParameterDirection.Output, 8);
            await Connection.ExecuteAsync("usp_surveystatus_update", objParam, null, null, CommandType.StoredProcedure);
            // return await result;
            return objParam.Get<int>("p_output");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}



