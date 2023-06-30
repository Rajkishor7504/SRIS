using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.ForgetPasswordMaster.Queries.GetForgetPasswordQueries;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Service
{
    public class ForgetPasswordMasterService : BaseRepository,IForgetPasswordMasterService
    {
        private readonly IConnectionFactory _connectionFactory;
        public ForgetPasswordMasterService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<List<ForgetPasswordMasterDto>> GetDetails(ForgetPasswordMasterDto dtls)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "USP_Master_ForgetPassword";
                    con.Open();
                    DynamicParameters objParam = new DynamicParameters();
                    objParam.Add("P_Action", dtls.Action);
                    objParam.Add("P_rollid", dtls.roleid);
                    objParam.Add("P_userid", dtls.userid);
                    objParam.Add("P_password", "");
                    objParam.Add("P_secretkey", "");
                    objParam.Add("P_updateby", 0);
                    objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                    var result = await con.QueryAsync<ForgetPasswordMasterDto>(Query, objParam, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> AddForgetMaster(ForgetPasswordMasterDto dtls)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("P_Action", dtls.Action);
                objParam.Add("P_rollid", 0);
                objParam.Add("P_userid", dtls.userid);
                objParam.Add("P_password", dtls.newpassword);
                objParam.Add("P_secretkey", dtls.secretkey);
                objParam.Add("P_updateby", dtls.createdby);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                var result = await Connection.ExecuteAsync("USP_Master_ForgetPassword", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
