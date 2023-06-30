using Dapper;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.UserRoleMasters.Queries.GetUserRoleMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SRIS.Application.Common.Interfaces;


namespace SRIS.Persistence.Service
{
    public class UserRoleService : BaseRepository, IUserRoleService
    {
        private readonly IConnectionFactory _connectionFactory;
        public UserRoleService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        //public async Task<int> AddUserRoleMaster(UserRoleMasterDto UserRole)
        //{
        //    DynamicParameters objParam = new DynamicParameters();
        //    objParam.Add("paction", UserRole.action);
        //    objParam.Add("proleid", UserRole.roleid);
        //    objParam.Add("prolename", UserRole.rolename);
        //    objParam.Add("pdescription", UserRole.description);
        //    objParam.Add("pcreatedby", UserRole.createdby);
        //    objParam.Add("poutput", "", DbType.Int32, ParameterDirection.Output, 8);
        //    var result = Connection.ExecuteAsync("usp_user_role_aed", objParam, null, null, CommandType.StoredProcedure);
        //    // return await result;
        //    return objParam.Get<int>("poutput");
        //}
        async Task<List<UserRoleMasterDto>>IUserRoleService.GetUserRoles()
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_getUserRole";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                   // param.Add("p_action", UserRole.action);
                    var result = await con.QueryAsync<UserRoleMasterDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.Where(pl => !pl.deletedflag).ToList();
                    //return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}