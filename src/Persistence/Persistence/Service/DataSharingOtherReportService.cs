using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.DataSharingOtherReport.Queries.GetDataSharingOtherReport;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Service
{
  public  class DataSharingOtherReportService: BaseRepository, IDataSharingOtherReportService
    {
        private readonly SRIS.Application.Common.Interfaces.IConnectionFactory _connectionFactory;
        public DataSharingOtherReportService(IConnectionFactory connectionFactory) : base(connectionFactory)//connectionFactory
        {
            _connectionFactory = connectionFactory;
        }
        async Task<List<DataSharingOtherReportDto>> IDataSharingOtherReportService.GetDataSharingOtherReport(DataSharingOtherReportDto requestreport)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_dynamic_datasharing";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", requestreport.p_action);
                    param.Add("p_location", requestreport.p_location);
                    param.Add("p_s", requestreport.p_s);
                    param.Add("p_shead", requestreport.p_shead);
                    var result = await con.QueryAsync<DataSharingOtherReportDto>(Query, param, commandType: CommandType.StoredProcedure);
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
