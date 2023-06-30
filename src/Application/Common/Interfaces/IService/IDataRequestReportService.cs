using SRIS.Application.DataRequestReport.Queries.GetDataRequestReport;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IService
{
    public interface IDataRequestReportService
    {
        Task<List<DataRequestReportDto>> GetDataRequestReport(DataRequestReportDto DataRequestReport);
    }
}
