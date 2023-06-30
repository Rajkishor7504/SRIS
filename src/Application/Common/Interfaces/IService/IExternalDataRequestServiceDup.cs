using SRIS.Application.ExternalDataRequest.Queries.GetExternalDataRequest;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
    public interface IExternalDataRequestServiceDup
    {
        Task<int> AddExternalDataRequest(ExternalDataRequestDupDto datarequest);
        Task<int> AddExternalDataRequestLatest(ExternalDataRequestDupDto datarequest);
        Task<List<DataSharingExcelSecond>> GenerateDataByDownloadExcelSecond(int requestId);// changes by Deepak(13-11-2022)
        Task<int> DataRequestNotification(ExternalDataRequestDupDto datarequest);
        Task<List<ExternalDataRequestDupDto>> GetExternalData(DataRequestCriteria datarequest);
        Task<List<ExternalDataRequestDupDto>> GetExternalDataView(ExternalDataRequestDupDto request);
        Task<int> ExternalDataRequestApproveReject(ExternalDataRequestDupDto datarequest);
        Task<List<ExternalData>> GenerateDataByRequest(int requestId);
        Task<List<ExternalDataCriteriaDisplayDup>> GetExternalDataCriteriaView(ExternalDataRequestDupDto request);
        Task<List<ExternalDataRequestDupDto>> GetExternalDataLatest(DataRequestCriteria datarequest);//Add By Rajkishor Patra(20-Oct-2022)
    }
}
