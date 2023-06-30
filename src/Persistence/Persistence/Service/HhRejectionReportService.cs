using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Persistence;
using SRIS.Application.HhRejectionReport.Queries.GetHhRejectionReport;
using System.Data;
using Dapper;
using System.Linq;
using SRIS.Application.Common.Interfaces;

namespace Persistence.Service
{
    public class HhRejectionReportService : BaseRepository, IHhRejectionReportService
    {
        private readonly IConnectionFactory _connectionFactory;
        public HhRejectionReportService(IConnectionFactory connectionFactory) : base(connectionFactory)//connectionFactory
        {
            _connectionFactory = connectionFactory;
        }
        async Task<List<HhRejectionReportDto>> IHhRejectionReportService.GetHhRejectionReport(HhRejectionReportDto RejectionReport)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_misreport_hhrejectionreport";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", RejectionReport.p_action);
                    param.Add("splanid", RejectionReport.splanid);
                    param.Add("regionid", RejectionReport.regionid);
                    param.Add("districtid", RejectionReport.districtid);
                    param.Add("wardid", RejectionReport.wardid);
                    param.Add("settlementid", RejectionReport.settlementid);
                    var result = await con.QueryAsync<HhRejectionReportDto>(Query, param, commandType: CommandType.StoredProcedure);
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
