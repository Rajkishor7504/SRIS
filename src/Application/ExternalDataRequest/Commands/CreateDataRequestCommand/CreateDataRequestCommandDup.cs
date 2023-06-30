﻿
using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.ExternalDataRequest.Queries.GetExternalDataRequest;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.ExternalDataRequest.Commands.CreateDataRequestCommand
{
    public class CreateDataRequestCommandDup : IRequest<int>
    {
        public int datarequest_id { get; set; }
        public int Request_UserId { get; set; }
        public RequestStatus Request_Status { get; set; }
        public string Request_Purpose { get; set; }
        public string Program_Name { get; set; }
        public string Program_Code { get; set; }
        public string Country { get; set; }
        public int Required_Service { get; set; }
        public string Other_Service_Request { get; set; }
        public string DataPath { get; set; }
        public string ModeOfSharing { get; set; }
        public int Total_HH_Registered { get; set; }
        public int createdby { get; set; }
        public DateTime createdon { get; set; }
        public int updatedby { get; set; }
        public DateTime updatedon { get; set; }
        public bool deletedflag { get; set; }
        public DataRequestCriteria RequestCriteria { get; set; }
        public int datarequest_id_linked { get; set; }
        public List<DuplicateExternalDupDto> p_Lists { get; set; }
        // public List<DataRequestCriteria> Lists { get; set; }
        public string organisationname { get; set; }

    }
    public class CreateDataRequestCommandDupHandler : IRequestHandler<CreateDataRequestCommandDup, int>
    {
        private readonly IExternalDataRequestServiceDup _iExternalDataRequestService;

        public CreateDataRequestCommandDupHandler(IExternalDataRequestServiceDup iExternalDataRequestService)
        {
            _iExternalDataRequestService = iExternalDataRequestService;
        }

        #region "To Create a new record for External Data Request"
        ///<summary>
        /// Created By Spandana Ray on 25/06/2021
        /// </summary>
        /// <parameter>Request Object of CreateDataRequestCommand</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To Create a new record for External Data Request</remarks>
        public async Task<int> Handle(CreateDataRequestCommandDup request, CancellationToken cancellationToken)
        {
            var entity = new ExternalDataRequestDupDto();
            entity.ActionCode = "V";
            var Lists = await _iExternalDataRequestService.GetExternalDataView(entity);
            if (request.Program_Code != "" && Lists.Any(d => d.Program_Code.ToLower() == request.Program_Code.ToLower()))
            {
                entity.datarequest_id = 0;
            }
            else
            {
                try
                {

                    entity.p_Lists = request.p_Lists;
                    entity.Request_UserId = request.Request_UserId;
                    entity.Request_Status = request.Request_Status;
                    entity.Request_Purpose = request.Request_Purpose;
                    entity.Program_Name = request.Program_Name;
                    entity.Program_Code = request.Program_Code;
                    entity.Country = request.Country;
                    entity.Required_Service = request.Required_Service;
                    entity.Other_Service_Request = request.Other_Service_Request;
                    entity.ModeOfSharing = request.ModeOfSharing;
                    entity.Total_HH_Registered = request.Total_HH_Registered;
                    entity.createdby = request.Request_UserId;
                    entity.updatedby = request.Request_UserId;
                    entity.RequestCriteria = request.RequestCriteria;
                    entity.datarequest_id_linked = request.datarequest_id_linked;
                    //entity.datarequest_id = await _iExternalDataRequestService.AddExternalDataRequest(entity);
                    entity.datarequest_id = await _iExternalDataRequestService.AddExternalDataRequestLatest(entity);
                    if (entity.datarequest_id == 200)
                    {
                        var organisationname = request.organisationname;
                        var Programmename = request.Program_Name;
                        entity.Request_UserId = 0;
                        entity.createdby = request.Request_UserId;
                        entity.Request_Purpose = " The " + organisationname + " has requested for data under the Programme Name: " + Programmename + " ,Pending for approval";
                        entity.Other_Service_Request = "/ExternalRequest/ExternalRequest/ApproveOrRejectMultipleRequest";
                        entity.datarequest_id = await _iExternalDataRequestService.DataRequestNotification(entity);
                    }
                }

                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
            return entity.datarequest_id;
        }
        #endregion
    }
}
