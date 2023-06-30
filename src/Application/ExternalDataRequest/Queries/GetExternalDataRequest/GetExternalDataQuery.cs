/*
* File Name : GetExternalDataQuery.cs
* class Name : GetExternalDataQuery, GetTodosQueryHandler
* Created Date : 27th Jul 2021
* Created By : Spandana Ray
* Description : Query to get the external data
*/

using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces.IService;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.ExternalDataRequest.Queries.GetExternalDataRequest
{
    public class GetExternalDataQuery : IRequest<ExternalDataRequestVM>
    {        
        public int datarequest_id { get; set; }
        public string ActionCode { get; set; }
    }
    public class GetExternalDataQueryHandler : IRequestHandler<GetExternalDataQuery, ExternalDataRequestVM>
    {
        private readonly IExternalDataRequestService _iExternalDataRequestService;
        private readonly IMapper _mapper;

        public GetExternalDataQueryHandler(IExternalDataRequestService iExternalDataRequestService, IMapper mapper)
        {
            _iExternalDataRequestService = iExternalDataRequestService;
            _mapper = mapper;
        }
        #region "To get the external data"
        ///<summary>
        /// Created By Spandana Ray on 27/07/2021
        /// </summary>
        /// <parameter>Request Object of GetExternalDataRequestQuery</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>ExternalDataRequestVM</returns>
        /// <remarks>To get the external data</remarks>
        public async Task<ExternalDataRequestVM> Handle(GetExternalDataQuery request, CancellationToken cancellationToken)
        {     if(request.ActionCode=="GD")
            {
                return new ExternalDataRequestVM
                {
                    ExternalDataLists = await _iExternalDataRequestService.GenerateDataByRequest(request.datarequest_id)
                    //ExternalDataLists = await _iExternalDataRequestService.GenerateDataByDownloadExcel(request.datarequest_id)
                };
            }
            else
            {
                return new ExternalDataRequestVM
                {
                    //ExternalDataLists = await _iExternalDataRequestService.GenerateDataByRequest(request.datarequest_id)
                    ExternalDataLists = await _iExternalDataRequestService.GenerateDataByDownloadExcel(request.datarequest_id)
                };
            }
           
        }
        #endregion
    }
}
