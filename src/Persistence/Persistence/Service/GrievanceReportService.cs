
using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.GrievanceReport;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Service
{
    class GrievanceReportService : BaseRepository, IGrievanceReportService
    {
        private readonly IConnectionFactory _connectionFactory;
        public GrievanceReportService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        async Task<List<GrievanceReportDto>> IGrievanceReportService.GrievanceReportList(GrievanceReportDto grievancereportlist)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_grievance_report";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("P_action", grievancereportlist.action);
                    param.Add("P_id", grievancereportlist.id);
                    param.Add("p_cid", grievancereportlist.grievanceconfigid);
                    param.Add("p_did", grievancereportlist.districtid);
                    param.Add("p_wid", grievancereportlist.wardid);
                    param.Add("p_rid", grievancereportlist.regionid);
                    param.Add("p_sid", grievancereportlist.settlementid);
                    param.Add("P_fromdate", grievancereportlist.fromdate==null?"": grievancereportlist.fromdate);
                    param.Add("P_todate", grievancereportlist.todate == null ? "" : grievancereportlist.todate);
                    var result = await con.QueryAsync<GrievanceReportDto>(Query, param, commandType: CommandType.StoredProcedure);
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
