using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.HhInterviewStatusReport.Queries.GetHhInterviewStatusReport;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Service
{
    public class HhInterviewStatusReportService : BaseRepository, IHhInterviewStatusReportService
    {
        private readonly IConnectionFactory _connectionFactory;
        public HhInterviewStatusReportService(IConnectionFactory connectionFactory) : base(connectionFactory)//connectionFactory
        {
            _connectionFactory = connectionFactory;
        }
        async Task<List<HhInterviewStatusReportDto>> IHhInterviewStatusReportService.GetHhInterviewStatusReport(HhInterviewStatusReportDto interviewstatusreport)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_hhinterviewstatus_report";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", interviewstatusreport.p_action);
                    param.Add("P_enumeratorname", interviewstatusreport.enumeratorname == null ? "" : interviewstatusreport.enumeratorname);
                    param.Add("P_supervisorname", interviewstatusreport.supervisorname == null ? "" : interviewstatusreport.supervisorname);
                    param.Add("searchid", interviewstatusreport.searchid);
                    param.Add("rgnid", interviewstatusreport.rgnid);
                    param.Add("distid", interviewstatusreport.distid);
                    param.Add("pfromdate", interviewstatusreport.fromdate == null ? "" : interviewstatusreport.fromdate);
                    param.Add("Ptodate", interviewstatusreport.todate == null ? "" : interviewstatusreport.todate);
                    var result = await con.QueryAsync<HhInterviewStatusReportDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        async Task<List<HhInterviewStatusReportDto>> IHhInterviewStatusReportService.Getenumeratorforrejecttion(HhInterviewStatusReportDto interviewstatusreport)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_hhinterviewstatus_report";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", interviewstatusreport.p_action);
                    param.Add("P_enumeratorname", interviewstatusreport.enumeratorname == null ? "" : interviewstatusreport.enumeratorname);
                    param.Add("P_supervisorname", interviewstatusreport.supervisorname == null ? "" : interviewstatusreport.supervisorname);
                    param.Add("searchid", interviewstatusreport.searchid);
                    param.Add("rgnid", interviewstatusreport.rgnid);
                    param.Add("distid", interviewstatusreport.distid);
                    param.Add("pfromdate", interviewstatusreport.fromdate == null ? "" : interviewstatusreport.fromdate);
                    param.Add("Ptodate", interviewstatusreport.todate == null ? "" : interviewstatusreport.todate);
                    var result = await con.QueryAsync<HhInterviewStatusReportDto>(Query, param, commandType: CommandType.StoredProcedure);
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
