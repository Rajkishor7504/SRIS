using SRIS.Application.MisReport.DemograpicConsolidateReportMaster.Qureies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IService.MisReport
{
    public interface IDemograpicConsolidateReportService
    {
        Task<List<DemograpicConsolidateReportDto>> DemograpicConsolidateReport(DemograpicConsolidateReportDto demograpicConsolidateReportDto);
    }
}
