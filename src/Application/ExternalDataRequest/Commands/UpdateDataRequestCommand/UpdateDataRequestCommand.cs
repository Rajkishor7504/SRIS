/*
* File Name : UpdateDataRequestCommand.cs
* class Name : UpdateDataRequestCommand, CreateOrganizationCommandHandler
* Created Date : 23 Jul 2021
* Created By : Spandana Ray
* Description : command class to approve or reject the request
*/

using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.ExternalDataRequest.Queries.GetExternalDataRequest;
using SRIS.Application.NotificationMasterItem.Queries.GetNotoficationMasterQueriesItem;
using SRIS.Domain.Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.ExternalDataRequest.Commands.UpdateDataRequestCommand
{
    public class UpdateDataRequestCommand: IRequest<int>
    {
        public int datarequest_id { get; set; }        
        public RequestStatus Request_Status { get; set; }
        public string remarks { get; set; }
        public string Feedback { get; set; }
        public string otherdatafile { get; set; }
        public IList<ExternalDataOther> ExternalDataOtherList { get; set; }
        public string ActionCode { get; set; }
        public int Request_UserId { get; set; }

    }
    public class UpdateDataRequestCommandHandler : IRequestHandler<UpdateDataRequestCommand, int>
    {
        private readonly IExternalDataRequestService _iExternalDataRequestService;
        private readonly IApplicationDbContext _context; private readonly IGrievanceService _igrievanceService;


        public UpdateDataRequestCommandHandler(IExternalDataRequestService iExternalDataRequestService, IApplicationDbContext context, IGrievanceService igrievanceService)
        {
            _iExternalDataRequestService = iExternalDataRequestService;
            _context = context; _igrievanceService = igrievanceService;
        }

        #region "Approve or Reject External Data Request"
        ///<summary>
        /// Created By Spandana Ray on 23/07/2021
        /// </summary>
        /// <parameter>Request Object of UpdateDataRequestCommand</parameter>
        /// <returns>Integer</returns>
        /// <remarks>Approve or Reject External Data Request</remarks>
        public async Task<int> Handle(UpdateDataRequestCommand request, CancellationToken cancellationToken)
        {
            var entity1 = new NotificationMasterDto();
            int ret = 0;
            var entity = new ExternalDataRequestDto();
            try
            { 
                if(request.ActionCode == "F")
                {
                    entity.datarequest_id = request.datarequest_id;
                    entity.Request_Status = request.Request_Status;
                    entity.Feedback = request.Feedback;
                    entity.Request_UserId = request.Request_UserId;
                    ret = await _iExternalDataRequestService.UpdateDataSharingFeedback(entity);
                }
                else
                {
                    entity.datarequest_id = request.datarequest_id;
                    entity.Request_Status = request.Request_Status;
                    entity.remarks = request.remarks;
                    entity.Feedback = request.Feedback;
                    if (!string.IsNullOrEmpty(request.otherdatafile))
                    {
                        entity.otherdatafile = request.datarequest_id.ToString() + Path.GetExtension(request.otherdatafile).ToLower();
                    }
                    ret = await _iExternalDataRequestService.ExternalDataRequestApproveReject(entity);

                    if (ret == 200 && request.Request_Status == RequestStatus.Processed && !string.IsNullOrEmpty(request.otherdatafile))
                    {
                        _context.t_datarequest_GenerateData1.AddRange(request.ExternalDataOtherList);
                        await _context.SaveChangesAsync(cancellationToken);
                    }
                    if (ret == 200)
                    {
                        entity1.refNo = request.datarequest_id;
                        entity1.ModuleName = "Data Request";
                        await _igrievanceService.UpdateGrievanceNotification(entity1);
                    }
                }
                
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return ret;
        }


        #endregion

       
    }
}
