/*
* File Name : CoreContextProvider.cs
* class Name : CoreContextProvider, StaticCoreContextExtensions
* Created Date : 29th May 2021
* Created By : Spandana Ray
* Description : To set the HttpContext & Session value
*/

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SRIS.Domain.Entities;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SRIS.Application.LoginAuthentication
{
   
    /// <summary>
    /// Core global support context
    /// Configuration, Service, HttpContext, User
    /// (It can be changed to the way of injection, in Here.
    /// MiddleWare middleware can intercept requests in the pipeline, 
    /// it can decide Yes. No. will transfer the request to the next middleware
    /// </summary>
    public class CoreContextProvider
    {
        private string LoginUserKey = ConstParameters.SysLoginUserKey;
        private string LoginProvider = ConstParameters.SysLoginProvider;

        private static IHttpContextAccessor _accessor;
        private readonly RequestDelegate _next;

        public static IConfiguration Configuration { get; set; }
        public static IHostingEnvironment HostingEnvironment { get; set; }
        public static HttpContext HttpContext => _accessor.HttpContext;

        public CoreContextProvider(RequestDelegate next, IHttpContextAccessor accessor,
            IHostingEnvironment hostingEnvironment)
        {
            _next = next;
            _accessor = accessor;
            HostingEnvironment = hostingEnvironment;
        }

        public async Task Invoke(HttpContext context)
        {
            //do somethings
            await _next(context);
        }

        /// <summary>
        /// Get MemCache context
        /// </summary>
        public static IMemCache MemCache
        {
            get
            {
                return GetService<IMemCache>();
            }
        }

        #region "To Get Current User"
        ///<summary>
        /// Created By Spandana Ray on 29/05/2021
        /// </summary>        
        /// <returns>MyUser</returns>
        /// <remarks>To Get Current User</remarks>
        public static MyUser CurrentSysUser
        {
            get
            {
                var claimsIdentity = (ClaimsIdentity)HttpContext.User.Identity;

                if (claimsIdentity == null || Convert.ToInt32(claimsIdentity.Claims.Count()) == 0)
                //if (claimsIdentity != null)
                {
                    {
                        //return null;
                       
                        throw new Exception("Session Out");
                    }
                }
                var claims = claimsIdentity.Claims;
                return new MyUser()
                {
                    Id = Convert.ToInt32(claims.Where(w => w.Type == ClaimTypes.Sid).Select(u => u.Value).FirstOrDefault()),
                    username = claims.Where(w => w.Type == ClaimTypes.Name).Select(u => u.Value).FirstOrDefault(),
                    userfullname = claims.Where(w => w.Type == ClaimTypes.GivenName).Select(u => u.Value).FirstOrDefault(),
                    usermobile = claims.Where(w => w.Type == ClaimTypes.MobilePhone).Select(u => u.Value).FirstOrDefault(),
                    email = claims.Where(w => w.Type == ClaimTypes.Email).Select(u => u.Value).FirstOrDefault(),
                    userroleid = Convert.ToInt32(claims.Where(w => w.Type == ClaimTypes.Role).Select(u => u.Value).FirstOrDefault()),
                    organisationname = claims.FirstOrDefault(w => w.Type == "OrganizationName").Value,
                   spotchecker = Convert.ToInt32(claims.FirstOrDefault(w => w.Type == "SpotChecker").Value),
                   registrationpurpose = Convert.ToInt32(claims.FirstOrDefault(w => w.Type == "PartnerRegPurpose").Value)

                };
            }
        }
        #endregion

        #region "To perform the logging"
        ///<summary>
        /// Created By Spandana Ray on 29/05/2021
        /// </summary>
        /// <parameter>string</parameter>
        /// <returns>ILogger</returns>
        /// <remarks>To perform the logging</remarks>
        public static ILogger GetLogger(string name = null)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                return GetService<ILoggerFactory>().CreateLogger(name);
            }
            return GetService<ILogger>();
        }
        public static T GetService<T>()
        {
            return (T)HttpContext.RequestServices.GetService(typeof(T));
        }
        #endregion
    }


    public static class StaticCoreContextExtensions
    {
        #region "To set the HttpContext & the configuration"
        ///<summary>
        /// Created By Spandana Ray on 29/05/2021
        /// </summary>
        /// <parameter>IServiceCollection</parameter>
        /// <parameter>IConfiguration</parameter>
        /// <returns>Void</returns>
        /// <remarks>To add the configuration</remarks>
        public static void AddCoreContextProvider(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IMemCache, MemCache>();

            //add configuration
            CoreContextProvider.Configuration = configuration;
        }

        /// <summary>
        /// Common context
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCoreContextProvider(this IApplicationBuilder app)
        {
            app.UseMiddleware<CoreContextProvider>();
            return app;
        }
        #endregion
    }
}
