using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.SurveyPlanning.EnumeratorProfile.Queries;
using SRIS.Domain.Common;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Service
{
   public class EnumeratorProfileService : BaseRepository, IEnumeratorProfileService
    {
        private readonly IConnectionFactory _connectionFactory;
        public EnumeratorProfileService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> AddEnumerator(EnumeratorProfileDto MyUser)
        {
            try
            {
            string enumeratorxml = CommonHelper.SerializeToXMLString(MyUser.Lists);
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_action", MyUser.action);
            objParam.Add("p_createdby", MyUser.createdby);
            objParam.Add("p_userxml", enumeratorxml);
            objParam.Add("p_myusername", MyUser.username);
            objParam.Add("p_fullname", MyUser.userfullname);
            objParam.Add("p_email", MyUser.email);
            objParam.Add("p_password", MyUser.password);
            objParam.Add("p_mobile", MyUser.usermobile);
            objParam.Add("p_Secretkey", MyUser.Secretkey);
            objParam.Add("p_startdate", MyUser.enumeratorstartdate);
            objParam.Add("p_enddate", MyUser.enumeratorenddate);
            objParam.Add("p_gender", MyUser.gender);
            objParam.Add("p_userroleid", MyUser.userroleid);
            objParam.Add("p_spotchecker", MyUser.spotchecker);
            objParam.Add("p_usertype", MyUser.usertype);
            objParam.Add("p_roleid", 0);
            objParam.Add("p_userId", MyUser.id);
            objParam.Add("p_output", "", DbType.Int32, ParameterDirection.Output, 8);
            await Connection.ExecuteAsync("usp_enumrator_aed", objParam, null, null, CommandType.StoredProcedure);
            return objParam.Get<int>("p_output");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        async Task<List<EnumeratorProfileDto>> IEnumeratorProfileService.GetEnumerator(EnumeratorProfileDto obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_get_enumerator";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", obj.action);
                    var result = await con.QueryAsync<EnumeratorProfileDto>(Query, param, commandType: CommandType.StoredProcedure);
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
