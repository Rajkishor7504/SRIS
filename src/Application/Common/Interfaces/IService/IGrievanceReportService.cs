using SRIS.Application.GrievanceReport;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
    public interface IGrievanceReportService
    {
        Task<List<GrievanceReportDto>> GrievanceReportList(GrievanceReportDto grievancereportlist);
    }
}
