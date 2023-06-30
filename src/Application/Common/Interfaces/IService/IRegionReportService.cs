using SRIS.Application.RegionReport.Queries.GetRegionSurvey;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IService
{
   public interface IRegionReportService
    {
        Task<List<SurveyRegionDto>> GetRegionReport(SurveyRegionDto RegionReport);
    }
}
