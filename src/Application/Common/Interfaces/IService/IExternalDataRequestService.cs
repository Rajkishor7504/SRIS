using SRIS.Application.ExternalDataRequest.Queries.GetExternalDataRequest;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IService
{
    public interface IExternalDataRequestService
    {
        Task<int> AddExternalDataRequest(ExternalDataRequestDto datarequest);
        Task<int> DataRequestNotification(ExternalDataRequestDto datarequest);

        Task<List<ExternalDataRequestDto>> GetExternalData(DataRequestCriteria datarequest);
        Task<List<ExternalDataRequestDto>> GetExternalDataView(ExternalDataRequestDto request);
        Task<List<ExternalDataRequestDto>> GetFeedbackDataView(ExternalDataRequestDto request); 
        Task<List<ExternalDataRequestDto>> GetDataSharingFeedback(ExternalDataRequestDto feedbackrequest);
        Task<int> ExternalDataRequestApproveReject(ExternalDataRequestDto datarequest);
        Task<List<ExternalData>> GenerateDataByRequest(int requestId);
        Task<List<ExternalData>> GenerateDataByDownloadExcel(int requestId);
        Task<List<ExternalDataCriteriaDisplay>> GetExternalDataCriteriaView(ExternalDataRequestDto request);
        Task<int> UpdateDataSharingFeedback(ExternalDataRequestDto datarequest);
        Task<List<ExternalDataRequestDto>> GetExternalDataViewLatest(ExternalDataRequestDto request);//created by Deepak Kumar Sahu(21-10-2022)
    }
}
