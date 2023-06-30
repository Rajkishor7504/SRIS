

using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Dashboard;
using SRIS.Application.Dashboard.Grievance;
using SRIS.Application.GrievanceComplaintsMasterItems.Queries.GetGrievanceComplaintsItem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service
{
    public class DashboardService : BaseRepository, IDashboardService
    {
        private readonly IConnectionFactory _connectionFactory;
        public DashboardService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        async Task<List<DemographicregisterdashboardDto>> IDashboardService.Getdemographicreg(DemographicregisterdashboardDto demographicreg)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_get_dmdashboard";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    //param.Add("action", grievance.action);
                    //param.Add("searchid", grievance.p_id);
                    //param.Add("leveldtlsid", 0);
                    //param.Add("puserId", grievance.userid);

                    var result = await con.QueryAsync<DemographicregisterdashboardDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        async Task<List<DashboardDto>> IDashboardService.GetdashboardGrievanceList(DashboardDto dashboardgrievancelist)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_get_dashboard";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("P_action", dashboardgrievancelist.action);
                    param.Add("P_id", dashboardgrievancelist.id);
                    var result = await con.QueryAsync<DashboardDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        async Task<List<DashboardDto>> IDashboardService.GetGrievanceGraphLists(DashboardDto dashboardgrievancelist)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_view_grievance_summary_graph";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    //param.Add("P_action", dashboardgrievancelist.action);
                    param.Add("p_year", dashboardgrievancelist.yeargv);
                    var result = await con.QueryAsync<DashboardDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        async Task<List<DashboardDto>> IDashboardService.GetFilterNonGraphList(DashboardDto dashboardgrievancelist,int committeeId, int locationid)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_dashboard_filter_year";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", dashboardgrievancelist.action);
                    param.Add("p_year", dashboardgrievancelist.yearga);
                    param.Add("p_id", dashboardgrievancelist.id);
                    param.Add("p_committeeId", committeeId);
                    param.Add("p_locationid", locationid);
                    var result = await con.QueryAsync<DashboardDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        async Task<List<DashboardDto>> IDashboardService.GetFilterPmtList(DashboardDto dashboardgrievancelist)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_pmt_graph_grievancelogin";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", dashboardgrievancelist.action);
                    param.Add("p_year", dashboardgrievancelist.yeargv);
                    //param.Add("p_id", dashboardgrievancelist.id);
                    //param.Add("p_committeeId", committeeId);
                    //param.Add("p_locationid", locationid);
                    var result = await con.QueryAsync<DashboardDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<GrievanceDashboardDto>> GetGrievanceDashboard(int committeeId, int locationid)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_Grievance_Dashboard_View";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_committeeId", committeeId);
                    param.Add("p_locationid", locationid);
                    var result = await con.QueryAsync<GrievanceDashboardDto>(Query, param, commandType: CommandType.StoredProcedure);
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
