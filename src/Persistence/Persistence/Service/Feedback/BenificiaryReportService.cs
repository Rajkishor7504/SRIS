using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.FeedbackReport.BenificiaryReport.Queries;
using System;
using SRIS.Persistence;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRIS.Application.Common.Interfaces.IService.Feedback;

namespace SRIS.Persistence.Service.Feedback
{
    public class BenificiaryReportService : BaseRepository, IBenificiaryReportService
    {
        private readonly IConnectionFactory _connectionFactory;
        public BenificiaryReportService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        async Task<List<BenificiaryReportDto>> IBenificiaryReportService.GetBenificiaryReport(BenificiaryReportDto benificiaryReportDto)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_feedbackreport";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("action", benificiaryReportDto.action);
                    param.Add("searchid", benificiaryReportDto.p_id);
                    //param.Add("p_pageno", benificiaryReportDto.pageno);
                    //param.Add("p_pagesize", benificiaryReportDto.pagesize);
                    param.Add("p_hhid", benificiaryReportDto.programdetailsid);
                    param.Add("leveldtlsid", 0);
                    //param.Add("p_datarequest_id", BenificiaryReportDto.datarequest_id);
                    var result = await con.QueryAsync<BenificiaryReportDto>(Query, param, commandType: CommandType.StoredProcedure);
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
