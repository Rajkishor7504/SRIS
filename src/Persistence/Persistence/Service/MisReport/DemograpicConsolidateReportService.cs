using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService.MisReport;
using SRIS.Application.MisReport.DemograpicConsolidateReportMaster.Qureies;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SIRS.Persistence.Service.MisReport
{
     public class DemograpicConsolidateReportService : BaseRepository, IDemograpicConsolidateReportService
    {
        private readonly IConnectionFactory _connectionFactory;
        public DemograpicConsolidateReportService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        async Task<List<DemograpicConsolidateReportDto>> IDemograpicConsolidateReportService.DemograpicConsolidateReport(DemograpicConsolidateReportDto demograpicConsolidateReportDto)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_demographicconsolidate_report";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("action", demograpicConsolidateReportDto.action);
                    param.Add("searchid", demograpicConsolidateReportDto.p_id);
                    //param.Add("datarequest_id", demograpicConsolidateReportDto.datarequest_id);
                    //param.Add("p_pageno", demograpicConsolidateReportDto.pageno);
                    //param.Add("p_pagesize", demograpicConsolidateReportDto.pagesize);
                    param.Add("leveldtlsid", 0);
                    param.Add("p_settlement", demograpicConsolidateReportDto.town);
                    //param.Add("p_datarequest_id", BenificiaryReportDto.datarequest_id);
                    var result = await con.QueryAsync<DemograpicConsolidateReportDto>(Query, param, commandType: CommandType.StoredProcedure);
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
