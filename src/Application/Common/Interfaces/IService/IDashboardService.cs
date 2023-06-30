using SRIS.Application.Dashboard;
using SRIS.Application.Dashboard.Grievance;
using SRIS.Application.GrievanceComplaintsMasterItems.Queries.GetGrievanceComplaintsItem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
   public interface IDashboardService
    {
        Task<List<DemographicregisterdashboardDto>> Getdemographicreg(DemographicregisterdashboardDto demographicreg);
        Task<List<DashboardDto>> GetdashboardGrievanceList(DashboardDto dashboardgrievancelist);
        Task<List<DashboardDto>> GetGrievanceGraphLists(DashboardDto dashboardgrievancelist);
        Task<List<DashboardDto>> GetFilterNonGraphList(DashboardDto dashboardgrievancelist, int committeeId, int locationid);
        Task<List<DashboardDto>> GetFilterPmtList(DashboardDto dashboardgrievancelist);
        Task<List<GrievanceDashboardDto>> GetGrievanceDashboard(int committeeId, int locationid);
    }
}
