using SRIS.Application.HhInterviewStatusReport.Queries.GetHhInterviewStatusReport;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IService
{
  public  interface IHhInterviewStatusReportService
    {
        Task<List<HhInterviewStatusReportDto>> GetHhInterviewStatusReport(HhInterviewStatusReportDto HhInterviewStatusReport);
        Task<List<HhInterviewStatusReportDto>> Getenumeratorforrejecttion(HhInterviewStatusReportDto HhInterviewStatusReport);
    }
}
