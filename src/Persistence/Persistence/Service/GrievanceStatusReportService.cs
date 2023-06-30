using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.GrievanceStatusReport.Queries.GetGrievanceStatus;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Service
{
  public class GrievanceStatusReportService: BaseRepository,IGrievanceStatusReportService
    {
        private readonly IConnectionFactory _connectionFactory;

        public GrievanceStatusReportService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        async Task<List<GrievanceStatusDto>> IGrievanceStatusReportService.GetGrievanceStatusReport(GrievanceStatusDto GrievanceStatusReport)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_misreport_grievancestatusreport";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", GrievanceStatusReport.p_action);
                    param.Add("searchid", GrievanceStatusReport.searchid);
                    param.Add("rgnid", GrievanceStatusReport.rgnid);
                    param.Add("distid", GrievanceStatusReport.distid);
                    param.Add("Grievanceid", GrievanceStatusReport.Grievanceid);
                    param.Add("pfromdate", GrievanceStatusReport.fromdate == null ? "" : GrievanceStatusReport.fromdate);
                    param.Add("Ptodate", GrievanceStatusReport.todate == null ? "" : GrievanceStatusReport.todate);
                    var result = await con.QueryAsync<GrievanceStatusDto>(Query, param, commandType: CommandType.StoredProcedure);
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
