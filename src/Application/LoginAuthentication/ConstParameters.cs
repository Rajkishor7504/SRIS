/*
* File Name : ConstParameters.cs
* class Name : ConstParameters
* Created Date : 29th May 2021
* Created By : Spandana Ray
* Description : Constant Parameters
*/

namespace SRIS.Application.LoginAuthentication
{
    /// <summary>
    /// Constant parameter set
    /// </summary>
    public class ConstParameters
    {
        public static string VerifyCodeKeyName = "netcore_session_verifycode";
        //CoreContextProvider.Configuration.GetSection() 

        public static string SysLoginUserKey = "netcore_loginuserkey_manage";

        public static string MemLoginUserKey = "netcore_loginuserkey_mem";

        public static string SysLoginProvider = CoreContextProvider.Configuration.GetSection("SystemProvider")["LoginProvider"];
    }
}
