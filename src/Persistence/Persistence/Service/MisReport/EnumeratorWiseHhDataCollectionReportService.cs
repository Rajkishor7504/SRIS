using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService.MisReport;
using SRIS.Application.MisReport.EnumeratorWiseHhDataCollectionReportMaster.Qureies;
using SRIS.Persistence;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
namespace Persistence.Service.MisReport
{
     public class EnumeratorWiseHhDataCollectionReportService : BaseRepository, IEnumeratorWiseHhDataCollectionReportService
    {
        private readonly IConnectionFactory _connectionFactory;
        public EnumeratorWiseHhDataCollectionReportService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        async Task<List<EnumeratorWiseHhDataCollectionReportDto>> IEnumeratorWiseHhDataCollectionReportService.EnumeratorWiseHhDataCollectionReport(EnumeratorWiseHhDataCollectionReportDto enumeratorWiseHhDataCollectionReportDto)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_misreport_enumeratorwisehhcollection";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("action", enumeratorWiseHhDataCollectionReportDto.action);
                    param.Add("searchid", enumeratorWiseHhDataCollectionReportDto.p_id);
                    param.Add("p_planid", enumeratorWiseHhDataCollectionReportDto.p_planid);
                    param.Add("p_regionid", enumeratorWiseHhDataCollectionReportDto.p_regionid);
                    param.Add("p_distid",enumeratorWiseHhDataCollectionReportDto.p_distid);
                    param.Add("leveldtlsid", 0);
                    var result = await con.QueryAsync<EnumeratorWiseHhDataCollectionReportDto>(Query, param, commandType: CommandType.StoredProcedure);
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
