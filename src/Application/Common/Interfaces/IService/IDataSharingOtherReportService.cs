using SRIS.Application.DataSharingOtherReport.Queries.GetDataSharingOtherReport;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IService
{
   public interface IDataSharingOtherReportService
    {
        Task<List<DataSharingOtherReportDto>> GetDataSharingOtherReport(DataSharingOtherReportDto DataRequestReport);
    }
}
