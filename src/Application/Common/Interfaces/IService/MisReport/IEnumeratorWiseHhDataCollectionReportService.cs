using SRIS.Application.MisReport.EnumeratorWiseHhDataCollectionReportMaster.Qureies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IService.MisReport
{
   public interface IEnumeratorWiseHhDataCollectionReportService
    {
        Task<List<EnumeratorWiseHhDataCollectionReportDto>> EnumeratorWiseHhDataCollectionReport(EnumeratorWiseHhDataCollectionReportDto enumeratorWiseHhDataCollectionReportDto);
    }
}
