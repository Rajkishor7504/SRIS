using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.LoginAuthentication;
using SRIS.Application.MyUsers.Queries.GetMyUser;
using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service
{
    public class MyUserService : BaseRepository, IMyUserService
    {
        private readonly IConnectionFactory _connectionFactory;
        public MyUserService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        ///// <summary>
        ///// IEnumerable Based Calls
        ///// </summary>
        ///// <returns></returns>
        //async Task<IEnumerable<MyUserDto>> IMyUserService.GetMyUsers()
        //{
        //    try
        //    {
        //        using (IDbConnection con = _connectionFactory.GetConnection)
        //        {
        //            string Query = "usp_getmyusers";
        //            con.Open();
        //            DynamicParameters param = new DynamicParameters();
        //            //param.Add("@PACTION", "B");
        //            //param.Add("@INTMSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
        //            var result = await con.QueryAsync<MyUserDto>(Query, param, commandType: CommandType.StoredProcedure);
        //            return result ;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// List Based Calls
        /// </summary>
        /// <returns></returns>
        async Task<List<MyUserDto>> IMyUserService.GetMyUsers()
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_getMyUsers";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    //param.Add("@PACTION", "B");
                    //param.Add("@INTMSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                    var result = await con.QueryAsync<MyUserDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Need to make this async
        public async Task<int> AddMyUser(MyUserDto MyUser)
        {
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_action", MyUser.action);
            objParam.Add("p_userId", MyUser.Id);
            objParam.Add("p_myusername", MyUser.username);
            objParam.Add("p_fullname", MyUser.userfullname);
            objParam.Add("p_email", MyUser.email);
            objParam.Add("p_password", MyUser.password);
            objParam.Add("p_mobile", MyUser.usermobile);
            objParam.Add("p_roleid", MyUser.roleid);
            objParam.Add("p_Secretkey", MyUser.Secretkey);
            objParam.Add("p_createdby", MyUser.createdby);
            objParam.Add("p_startdate", MyUser.startdate);
            objParam.Add("p_enddate", MyUser.enddate);
            objParam.Add("p_gender", MyUser.gender);
            objParam.Add("p_userroleid", MyUser.userroleid);
            objParam.Add("p_spotchecker", 0);
            objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
            var result = Connection.ExecuteAsync("usp_myuser_aed", objParam, null, null, CommandType.StoredProcedure);
            return objParam.Get<int>("p_out");
        }

        //async Task<List<int>> IMyUserService.AddMyUser(MyUserDto MyUser)
        //{
        //    DynamicParameters objParam = new DynamicParameters();
        //    objParam.Add("pchr_action", "a");
        //    objParam.Add("pchr_myusername", MyUser.username);
        //    objParam.Add("@pint_output", "", DbType.Int32, ParameterDirection.Output, 8);
        //    var result = Connection.ExecuteScalarAsync("usp_myuser_aed", objParam, null, null, CommandType.StoredProcedure);
        //    return await result;
        //}

        async Task<int> IMyUserService.DeleteMyUser(int? MyUserId)
        {
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_action", "D");
            objParam.Add("p_userId", MyUserId);
            objParam.Add("p_myusername", "");
            objParam.Add("p_fullname", "");
            objParam.Add("p_email", "");
            objParam.Add("p_password", "");
            objParam.Add("p_mobile", "");
            objParam.Add("p_roleid",0);
            objParam.Add("p_Secretkey", "");
            objParam.Add("p_createdby", 1);
            objParam.Add("p_startdate", null);
            objParam.Add("p_enddate", null);
            objParam.Add("p_gender", 0);
            objParam.Add("p_userroleid", 0);
            objParam.Add("p_spotchecker", 0);
            objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
            var result = Connection.ExecuteAsync("usp_myuser_aed", objParam, null, null, CommandType.StoredProcedure);
            return objParam.Get<int>("p_out");
        }

        async Task<MyUserDto> IMyUserService.GetMyUser(int? MyUserId)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_getMyUsers";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    var result = await con.QueryAsync<MyUserDto>(Query, param, commandType: CommandType.StoredProcedure);
                    var myuser = result.FirstOrDefault(u => u.Id == MyUserId.Value);
                    return myuser;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<int> IMyUserService.UpdateMyUser(MyUserDto MyUser)
        {
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_action", MyUser.action);
            objParam.Add("p_userId", MyUser.Id);
            objParam.Add("p_myusername", MyUser.username);
            objParam.Add("p_fullname", MyUser.userfullname);
            objParam.Add("p_email", MyUser.email);
            objParam.Add("p_password", MyUser.password);
            objParam.Add("p_mobile", MyUser.usermobile);
            objParam.Add("p_roleid", MyUser.roleid);
            objParam.Add("p_Secretkey", "");
            objParam.Add("p_createdby", MyUser.createdby);
            objParam.Add("p_startdate", MyUser.startdate);
            objParam.Add("p_enddate", MyUser.enddate);
            objParam.Add("p_gender", MyUser.gender);
            objParam.Add("p_userroleid", MyUser.userroleid);
            objParam.Add("p_spotchecker", 0);
            objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
            var result = Connection.ExecuteAsync("usp_myuser_aed", objParam, null, null, CommandType.StoredProcedure);
            return objParam.Get<int>("p_out");
        }

    }
}
