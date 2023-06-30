using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.MemberInformationReport.Queries.GetMemberInformation;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Service
{
   public class MemberInformationReportService:BaseRepository, IMemberInformationReportService
    {
        private readonly IConnectionFactory _connectionFactory;
        public MemberInformationReportService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        async Task<List<MemberInformationDto>> IMemberInformationReportService.GetMemberInformation(MemberInformationDto RegionReport)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_misreport_memberinformation";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", RegionReport.p_action);
                    param.Add("regionid", RegionReport.regionid);
                    param.Add("splanid", RegionReport.splanid);
                    param.Add("districtid", RegionReport.districtid);
                    param.Add("wardid", RegionReport.wardid);
                    param.Add("settlementid", RegionReport.settlementid);
                    param.Add("p_hhid", RegionReport.hhid);
                    var result = await con.QueryAsync<MemberInformationDto>(Query, param, commandType: CommandType.StoredProcedure);
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
