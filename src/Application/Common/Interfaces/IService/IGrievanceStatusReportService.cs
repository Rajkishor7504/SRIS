using SRIS.Application.GrievanceStatusReport.Queries.GetGrievanceStatus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IService
{
 public  interface IGrievanceStatusReportService
    {
        Task<List<GrievanceStatusDto>> GetGrievanceStatusReport(GrievanceStatusDto GrievanceStatusReport);
    }
}
