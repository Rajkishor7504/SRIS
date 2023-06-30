using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Userlogin_lgouttime.Queries.Userlogin_logouttimeQuery;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Service
{
    public class UserLoginlouttimeService : BaseRepository, IUserloginlogouttimeServices
    {
        private readonly IConnectionFactory _connectionFactory;
        public UserLoginlouttimeService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> Updateduser(Userlogin_logouttimeDto obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    DynamicParameters objParam = new DynamicParameters();
                    objParam.Add("P_id", obj.id);
                    objParam.Add("P_logouttime", obj.logout_time);
                    objParam.Add("p_output", "", DbType.Int32, ParameterDirection.Output, 8);
                    var result = Connection.ExecuteAsync("usp_userlogin_logouttime", objParam, null, null, CommandType.StoredProcedure);
                    return objParam.Get<int>("p_output");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

    }
    
}
