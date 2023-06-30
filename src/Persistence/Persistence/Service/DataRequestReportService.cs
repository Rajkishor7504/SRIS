using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.DataRequestReport.Queries.GetDataRequestReport;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Service
{
   public class DataRequestReportService : BaseRepository, IDataRequestReportService
    {
        private readonly IConnectionFactory _connectionFactory;
        public DataRequestReportService(IConnectionFactory connectionFactory) : base(connectionFactory)//connectionFactory
        {
            _connectionFactory = connectionFactory;
        }
        async Task<List<DataRequestReportDto>> IDataRequestReportService.GetDataRequestReport(DataRequestReportDto requestreport)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_misreport_datarequestreport";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", requestreport.p_action);
                    param.Add("orgid", requestreport.organisationid);
                    param.Add("pfromdate", requestreport.fromdate==null?"": requestreport.fromdate);
                    param.Add("Ptodate", requestreport.todate==null?"": requestreport.todate);
                    var result = await con.QueryAsync<DataRequestReportDto>(Query, param, commandType: CommandType.StoredProcedure);
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
/*
  param.Add("P_fromdate", grievancereportlist.fromdate==null?"": grievancereportlist.fromdate);
  param.Add("P_todate", grievancereportlist.todate == null ? "" : grievancereportlist.todate);
 */