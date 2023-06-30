using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.SurveyPlanning.AssignSurveyManagerMaster.Query.GetassignSurveyManagerItem;
using SRIS.Domain.Common;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service
{
    public class AssignSurveyManagerService: BaseRepository, IAssignSurveyManagerService
    {
        private readonly IConnectionFactory _connectionFactory;
        public AssignSurveyManagerService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        async Task<List<AssignSurveyManagerDto>> IAssignSurveyManagerService.Getsurveymanagerdetails(AssignSurveyManagerDto mysurveymangdetails)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_getassignsurveymanager";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    var result = await con.QueryAsync<AssignSurveyManagerDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Createsurveymanager(AssignSurveyManagerDto asignsurveymanager)
        {
            try
            {

            
            string surveymanagerxml = CommonHelper.SerializeToXMLString(asignsurveymanager.Lists);
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_action", asignsurveymanager.action);
            objParam.Add("p_createdby", asignsurveymanager.createdby);
            objParam. Add("p_surveymanagerxml", surveymanagerxml);
            objParam.Add("p_output", "", DbType.Int32, ParameterDirection.Output, 8);
            await Connection.ExecuteAsync("usp_asignsurveymanager_aed", objParam, null, null, CommandType.StoredProcedure);
            return objParam.Get<int>("p_output");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> deletesurveymanag(int? asignmangid)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    DynamicParameters objParam = new DynamicParameters();
                    objParam.Add("p_assignmanagerid", asignmangid);
                    objParam.Add("p_output", "", DbType.Int32, ParameterDirection.Output, 8);
                    await Connection.ExecuteAsync("usp_dltsurveymanager", objParam, null, null, CommandType.StoredProcedure);
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
