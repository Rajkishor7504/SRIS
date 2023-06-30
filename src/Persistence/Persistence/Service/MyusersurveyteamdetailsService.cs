using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.My_UsersurveyTeamDetails.Query;
using SRIS.Application.SurveyPlanning.SurveyTeamMasterItem.Query.GetSurveyTeamMasterItem;
using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service
{
    public class MyusersurveyteamdetailsService : BaseRepository, ImyusersurveyteamdetailsService
    {
        private readonly IConnectionFactory _connectionFactory;
        public MyusersurveyteamdetailsService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        async Task<List<My_usersurveyTeamdetailsDto>> ImyusersurveyteamdetailsService.Getmusurveydetails(My_usersurveyTeamdetailsDto myusteamdetails)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_myuser_surveyteamdetails";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", myusteamdetails.action);
                    var result = await con.QueryAsync<My_usersurveyTeamdetailsDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        async Task<List<SurveyTeamMasterDto>> ImyusersurveyteamdetailsService.Getteamdetails(SurveyTeamMasterDto teamdetails)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_survey_createteam_ve";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", teamdetails.action);
                    param.Add("p_planid", teamdetails.planid);
                    param.Add("p_searchid", teamdetails.searchid);
                    var result = await con.QueryAsync<SurveyTeamMasterDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> CreateTeam(SurveyTeamMasterDto obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    
                    string teamdetailsxml = CommonHelper.SerializeToXMLString(obj.Lists);
                    DynamicParameters objParam = new DynamicParameters();
                    objParam.Add("p_surveyplanid", obj.surveyplanid);
                    objParam.Add("p_teamname", obj.teamname);
                    objParam.Add("p_description", obj.description);
                    objParam.Add("p_createdby", obj.createdby);
                    objParam.Add("p_teamdetailsxml", teamdetailsxml);
                    objParam.Add("p_output", "", DbType.Int32, ParameterDirection.Output, 8);
                    var result = Connection.ExecuteAsync("usp_addsurveyteamdetails", objParam, null, null, CommandType.StoredProcedure);
                    return objParam.Get<int>("p_output");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        public async Task<int> deleteTeam(int? teamid)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    DynamicParameters objParam = new DynamicParameters();
                    objParam.Add("p_teamid", teamid);
                    objParam.Add("p_output", "", DbType.Int32, ParameterDirection.Output, 8);
                    var result = Connection.ExecuteAsync("usp_dltteamdetails", objParam, null, null, CommandType.StoredProcedure);
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

