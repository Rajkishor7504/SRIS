using SRIS.Application.LoginLogoutReport.Queries.GetLoginLogoutReport;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IService
{
   public interface ILoginLogoutReportService
    {
        //interface
        Task<List<LoginLogoutReportDto>> GetLoginLogoutReport(LoginLogoutReportDto LoginLogoutReport);
    }
}
