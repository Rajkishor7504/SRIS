using Dapper;
using SRIS.Application;
using SRIS.Application.AccessLinkMasters.Queries.GetAccessLinkMaster;
using SRIS.Application.Common;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service
{
    public class SysUserService : BaseRepository, ISysUserService
    {
        string strOutput = string.Empty;
        private readonly IConnectionFactory _connectionFactory;

        public SysUserService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
 
        public MyUser CheckLogin(string userName, string password,MyUser sysuser)
        {
            MyUser sysUser = new MyUser();
          
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_um_login";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();

                    param.Add("p_username", sysuser.username);
                    var result = con.QueryAsync<MyUser>(Query, param, commandType: CommandType.StoredProcedure);
                    foreach (var item in result.Result)
                    {
                        sysUser.username = item.username;
                        sysUser.Secretkey = item.Secretkey;
                        sysUser.password = item.password;
                        sysUser.userfullname = item.userfullname;
                        sysUser.usermobile = item.usermobile;
                        sysUser.userroleid = item.userroleid;
                        sysUser.spotchecker = item.spotchecker;
                        sysUser.email = item.email;
                        sysUser.gendername = item.gendername;
                        sysUser.Id = item.Id;
                        sysUser.organisationname = item.organisationname;
                        sysUser.spotcheckerstatus = item.spotcheckerstatus;
                        sysUser.registrationpurpose=item.registrationpurpose;
                        
                    }
                }
                if (sysUser.username != null)
                {
                    string dbPassword = Md5Hash.Md5(DESEncrypt.Encrypt(password.ToLower(), sysUser.Secretkey).ToLower(), 32).ToLower();
                    if (dbPassword == sysUser.password)
                    {
                        return sysUser;
                    }
                    else
                    {
                        throw new Exception("Invalid password.");
                    }
                }
                else
                {
                    throw new Exception("The account does not exist, please re-enter");
                }
        }

        public string ForgotPasswordManage(MyUser userMaster, string strAction)
        {
            try
            {

            
            //Create the parameters
            var p = new DynamicParameters();
            p.Add("PAction", strAction);
            p.Add("PUserid", userMaster.Id);
            p.Add("PUsername", userMaster.username);
            p.Add("PEmail", userMaster.email);
            p.Add("PMobile", userMaster.usermobile);
            p.Add("POtp", userMaster.otp);
            p.Add("PPassword", userMaster.password);
            p.Add("PSecretKey", userMaster.Secretkey);
            p.Add("PMsgOut", dbType: DbType.String, direction: ParameterDirection.Output);
            Connection.Query<int>("USP_USER_FORGOTPASSWARD", p, commandType: CommandType.StoredProcedure);
            strOutput = p.Get<string>("PMsgOut");
            return strOutput;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<AccessLinkMasterDto> UserLinkAccessVIew(int userid)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_getaccesslinks";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("pint_userid", userid);
                    var result = con.Query<AccessLinkMasterDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region GetUserLinks
        /// <summary>
        /// Function to get all the link whose access is provided to the user 
        /// based on the user id 
        /// </summary>
        /// <param name="intUserId">User id</param>
        /// <returns>List<MenuItem></returns>
        public List<MenuItem> GetUserLinks(int intUserId)
        {
            return _connectionFactory.GetConnection.Query<MenuItem>("usp_getuserlinks", new { chr_Action = 'V', int_user_id = intUserId },
                commandType: CommandType.StoredProcedure).ToList();
        }

        public MyUser GetUserDetailsByUserId(int userid)
        {
            MyUser sysUser = null;

            using (IDbConnection con = _connectionFactory.GetConnection)
            {
                string Query = "usp_getMyUsers";
                con.Open();
                DynamicParameters param = new DynamicParameters();
                var result = con.Query<MyUser>(Query, param, commandType: CommandType.StoredProcedure);
                if (result.Any())
                {
                    sysUser = result.FirstOrDefault(u => u.Id == userid);
                }
            }
            return sysUser;
        }
        #endregion

        public async Task<int> ChangePassword(MyUser user)
        {
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_action", "CP");
            objParam.Add("p_userId", user.Id);
            objParam.Add("p_myusername", user.username);
            objParam.Add("p_fullname", user.userfullname);
            objParam.Add("p_email", user.email);
            objParam.Add("p_password", user.password);
            objParam.Add("p_mobile", user.usermobile);
            objParam.Add("p_Secretkey", user.Secretkey);
            objParam.Add("p_createdby", user.Id);

            objParam.Add("p_startdate", "");
            objParam.Add("p_enddate", "");
            objParam.Add("p_gender", 0);
            objParam.Add("p_userroleid", user.userroleid);
            objParam.Add("p_spotchecker", 0);
            objParam.Add("p_roleid", 0);
            objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
            //await Connection.Query<int>("usp_myuser_aed", objParam, commandType: CommandType.StoredProcedure);
            
            await Connection.ExecuteAsync("usp_myuser_aed", objParam, null, null, CommandType.StoredProcedure);
            return objParam.Get<int>("p_out");
        }

        #region
        public MyUser CheckMobileLogin(string userName, string password,int userType)
        {
            MyUser sysUser = null;
            using (IDbConnection con = _connectionFactory.GetConnection)
            {
                string Query = "usp_getMyUsersM";
                con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("p_userType", userType);
                var result = con.Query<MyUser>(Query, param, commandType: CommandType.StoredProcedure);
                if (result.Any())
                {
                    sysUser = result.FirstOrDefault(u => u.username.ToLower() == userName.ToLower());
                }
            }

            if (sysUser != null)
            {
               string dbPassword = Md5Hash.Md5(DESEncrypt.Encrypt(password.ToLower(), sysUser.Secretkey).ToLower(), 32).ToLower();
                if (dbPassword == sysUser.password)
                {
                    return sysUser;
                }
                else
                {
                    throw new Exception("Invalid password.");
                }
            }
            else
            {
                throw new Exception("The account does not exist, please re-enter");
            }
            return sysUser;
        }

        public MyUser GetEnumerator(int userid, int teamid)
        {
            throw new NotImplementedException();
        }
        #endregion
        //public MyUser CheckLogin(string userName, string password)
        //{
        //    MyUser sysUser = null;

        //    using (IDbConnection con = _connectionFactory.GetConnection)
        //    {
        //        string Query = "usp_getMyUsers";
        //        con.Open();
        //        DynamicParameters param = new DynamicParameters();
        //        var result = con.Query<MyUser>(Query, param, commandType: CommandType.StoredProcedure);
        //        if (result.Any())
        //        {
        //            sysUser = result.FirstOrDefault(u => u.username.ToLower() == userName.ToLower());
        //        }
        //    }

        //    if (sysUser != null)
        //    {
        //        string dbPassword = Md5Hash.Md5(DESEncrypt.Encrypt(password.ToLower(), sysUser.Secretkey).ToLower(), 32).ToLower();
        //        if (dbPassword == sysUser.password)
        //        {
        //            return sysUser;
        //        }
        //        else
        //        {
        //            throw new Exception("Invalid password.");
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception("The account does not exist, please re-enter");
        //    }
        //    //return sysUser;
        //}
    }
}
