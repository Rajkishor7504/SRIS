using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Report.DataSharingReport;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service
{
    class DatasharingReportservice:BaseRepository, IDatasharingReportService
    {
        private readonly IConnectionFactory _connectionFactory;
        public DatasharingReportservice(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        async Task<List<DataSharingReportDto>> IDatasharingReportService.DatasharingReportList(DataSharingReportDto datasharingreportlist)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_datasharing_report";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("P_action", datasharingreportlist.action);
                    param.Add("P_uid", 0);
                    param.Add("P_oid", datasharingreportlist.catagory);
                    //param.Add("P_orgid", "ghghxcgbcgcg");
                    param.Add("P_orgid", datasharingreportlist.orgname);
                   // param.Add("P_orgid", 52);
                    param.Add("P_fromdate", datasharingreportlist.fid == null ? "" : datasharingreportlist.fid);
                    param.Add("P_todate", datasharingreportlist.tid == null ? "" : datasharingreportlist.tid);
                    var result = await con.QueryAsync<DataSharingReportDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //async Task<List<DataSharingReportDto>> IDatasharingReportService.DatasharingReportList1(DataSharingReportDto datasharingreportlist)
        //{
        //    try
        //    {
        //        using (IDbConnection con = _connectionFactory.GetConnection)
        //        {
        //            string Query = "usp_datasharing_report";
        //            con.Open();
        //            DynamicParameters param = new DynamicParameters();
        //            param.Add("P_action", datasharingreportlist.action);
        //            param.Add("P_uid", datasharingreportlist.userid);
        //            //param.Add("P_oid", datasharingreportlist.catagory);
        //            param.Add("P_orgid", "ghghxcgbcgcg");
        //            // param.Add("P_orgid", datasharingreportlist.orgname);
        //            param.Add("P_orgid", 52);
        //            param.Add("P_fromdate", datasharingreportlist.fid == null ? "" : datasharingreportlist.fid);
        //            param.Add("P_todate", datasharingreportlist.tid == null ? "" : datasharingreportlist.tid);
        //            var result = await con.QueryAsync<DataSharingReportDto>(Query, param, commandType: CommandType.StoredProcedure);
        //            return result.ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
