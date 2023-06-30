using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.LoginLogoutReport.Queries.GetLoginLogoutReport;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Service
{
  public  class LoginLogoutReportService : BaseRepository, ILoginLogoutReportService
    {
        //service
        private readonly IConnectionFactory _connectionFactory;
        public LoginLogoutReportService(IConnectionFactory connectionFactory) : base(connectionFactory)//connectionFactory
        {
            _connectionFactory = connectionFactory;
        }
        async Task<List<LoginLogoutReportDto>> ILoginLogoutReportService.GetLoginLogoutReport(LoginLogoutReportDto loginlogoutreport)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_misreport_login_logout_details";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", loginlogoutreport.p_action);
                    param.Add("pfromdate", loginlogoutreport.fromdate == null ? "" : loginlogoutreport.fromdate);
                    param.Add("Ptodate", loginlogoutreport.todate == null ? "" : loginlogoutreport.todate);
                    var result = await con.QueryAsync<LoginLogoutReportDto>(Query, param, commandType: CommandType.StoredProcedure);
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
