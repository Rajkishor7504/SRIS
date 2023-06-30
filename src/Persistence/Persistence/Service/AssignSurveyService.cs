using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.SurveyPlanning.AssignSurvey.Queries;
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
   public class AssignSurveyService : BaseRepository, IAssignSurveyService
    {
        private readonly IConnectionFactory _connectionFactory;
        public AssignSurveyService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> AddAssignSurvey(AssignSurveyDto assignSurvey)
        {
            string AssignSurveyXML = CommonHelper.SerializeToXMLString(assignSurvey.Lists);
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_action", assignSurvey.action);
            objParam.Add("p_assignsupid", assignSurvey.assignsupid);
            objParam.Add("p_assignmentid", assignSurvey.assignmentid);
            objParam.Add("p_userid", assignSurvey.userid);
            objParam.Add("p_createdby", assignSurvey.createdby);
            objParam.Add("p_assignenumid", assignSurvey.assignenumid);
            objParam.Add("p_assigndeviceid", assignSurvey.assigndeviceid);
            objParam.Add("p_deviceid", assignSurvey.deviceid);
            objParam.Add("p_assignSurveyXML", AssignSurveyXML);
            objParam.Add("p_output", "", DbType.Int32, ParameterDirection.Output, 8);
            var result = Connection.ExecuteAsync("usp_assignsurvey_aed", objParam, null, null, CommandType.StoredProcedure);
            return objParam.Get<int>("p_output");
        }
        public async Task<int> AddAssignSurveyList(IList<AssignSurveyDto> Surveylist)
        {
            int result = 0;
            foreach (var location in Surveylist)
            {
                result = await AddAssignSurvey(location);
            }
            return result;
        }
        async Task<List<AssignSurveyDto>> IAssignSurveyService.GetAssignedSurvey(AssignSurveyDto assignsurvey)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_getassignedsurvey";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", assignsurvey.action);
                    param.Add("p_searchid", assignsurvey.searchid);
                    var result = await con.QueryAsync<AssignSurveyDto>(Query, param, commandType: CommandType.StoredProcedure);
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
