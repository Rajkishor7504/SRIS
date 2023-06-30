using SRIS.Application.Report.DataSharingReport;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
    public interface IDatasharingReportService
    {
        Task<List<DataSharingReportDto>> DatasharingReportList(DataSharingReportDto datasharingreportlist);
    }
}
