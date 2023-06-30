using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SRIS.Application.HhRejectionReport.Queries.GetHhRejectionReport;

namespace SRIS.Application.Common.Interfaces.IService
{
   public interface IHhRejectionReportService
    {
        Task<List<HhRejectionReportDto>> GetHhRejectionReport(HhRejectionReportDto RejectionReport);
    }
}
