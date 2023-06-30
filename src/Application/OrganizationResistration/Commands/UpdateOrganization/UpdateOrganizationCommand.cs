/*
* File Name : UpdateOrganizationCommand.cs
* class Name : UpdateOrganizationCommand, CreatGlobalLinkMasterCommandHandler
* Created Date : 10 Jun 2021
* Created By : Spandana Ray
* Description : command class to update the organization
*/

using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.NotificationMasterItem.Queries.GetNotoficationMasterQueriesItem;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.OrganizationResistration.Commands.UpdateOrganization
{
    public class UpdateOrganizationCommand : IRequest<int>
    {
        public int organisationid { get; set; }
        public string organisationname { get; set; }
        public RegistrationStatus status { get; set; }
        public string password { get; set; }
        public string Secretkey { get; set; }
    }
    public class UpdateOrganizationCommandHandler : IRequestHandler<UpdateOrganizationCommand, int>
    {
        private readonly IOrganizationService _iOrganizationService; private readonly IGrievanceService _igrievanceService;


        public UpdateOrganizationCommandHandler(IOrganizationService iOrganizationService, IGrievanceService igrievanceService)
        {
            _iOrganizationService = iOrganizationService;
            _igrievanceService = igrievanceService;
        }

        #region "To Reject Organization registration request"
        ///<summary>
        /// Created By Spandana Ray on 10/06/2021
        /// </summary>
        /// <parameter>Request Object of UpdateOrganizationCommand</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Unit</returns>
        /// <remarks>To Reject Organization registration request</remarks>
        public async Task<int> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var entity1 = new NotificationMasterDto();
            var entity = await _iOrganizationService.GetOrganizationById(request.organisationid);

            if (entity == null)
            {
                throw new NotFoundException(nameof(OrgRegistration), request.organisationid);
            }
            entity.password = request.password;
            entity.Secretkey = request.Secretkey;
            entity.status = request.status;
            int ret = await _iOrganizationService.ApproveOrRejectOrganization(entity);
            if (ret == 0)
            {
                entity1.refNo = request.organisationid;
                entity1.ModuleName = "Partner Registration";
                await _igrievanceService.UpdateGrievanceNotification(entity1);
            }
            return ret;
        }
        #endregion
    }
}
