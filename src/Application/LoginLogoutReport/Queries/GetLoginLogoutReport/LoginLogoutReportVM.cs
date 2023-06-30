using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.LoginLogoutReport.Queries.GetLoginLogoutReport
{
  public  class LoginLogoutReportVM
    {
        //vm class
        public LoginLogoutReportVM()
        {
            Lists = new List<LoginLogoutReportDto>();
        }

        public IList<LoginLogoutReportDto> Lists { get; set; }
        public string p_action { get; set; }
        public string username { get; set; }
        public string userfullname { get; set; }
        public string rolename { get; set; }
        public string ipaddress { get; set; }
        public string logintime { get; set; }
        public string logouttime { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
    }
}
