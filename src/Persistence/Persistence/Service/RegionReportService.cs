using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.RegionReport.Queries.GetRegionSurvey;
using SRIS.Domain.Common;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Service
{
   public class RegionReportService : BaseRepository, IRegionReportService
    {
        private readonly IConnectionFactory _connectionFactory;
        public RegionReportService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        async Task<List<SurveyRegionDto>> IRegionReportService.GetRegionReport(SurveyRegionDto RegionReport)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_misreport_getregionsurvey";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", RegionReport.p_action);
                    param.Add("regionid", RegionReport.regionid);
                    param.Add("splanid", RegionReport.splanid);
                    param.Add("districtid", RegionReport.districtid);
                    param.Add("wardid", RegionReport.wardid);
                    param.Add("settlementid", RegionReport.settlementid);
                    var result = await con.QueryAsync<SurveyRegionDto>(Query, param, commandType: CommandType.StoredProcedure);
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
