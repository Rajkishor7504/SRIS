using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService.Feedback;
using SRIS.Application.FeedbackReport.BenificiaryPaymentReport.Queries;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SRIS.Persistence.Service.Feedback
{
    public class BenificiaryPaymentReportService : BaseRepository, IBenificiaryPaymentReportService
    {
        private readonly IConnectionFactory _connectionFactory;
        public BenificiaryPaymentReportService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        async Task<List<BenificiaryPaymentReportDto>> IBenificiaryPaymentReportService.BenificiaryPaymentReport(BenificiaryPaymentReportDto benificiaryPaymentReportDto)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_feedback_report_benificiary";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("action", benificiaryPaymentReportDto.action);
                    param.Add("searchid", benificiaryPaymentReportDto.p_id);
                    param.Add("datarequest_id", benificiaryPaymentReportDto.datarequest_id);
                    param.Add("leveldtlsid", 0);
                    var result = await con.QueryAsync<BenificiaryPaymentReportDto>(Query, param, commandType: CommandType.StoredProcedure);
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
