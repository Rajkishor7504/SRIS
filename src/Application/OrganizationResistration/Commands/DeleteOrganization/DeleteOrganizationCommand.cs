/*
* File Name : DeleteOrganizationCommand.cs
* class Name : DeleteOrganizationCommand, DeleteMasterCommandHandler
* Created Date : 14 Jun 2021
* Created By : Spandana Ray
* Description : command class to delete the Organization
*/
using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.OrganizationResistration.Commands.DeleteOrganization
{
    public class DeleteOrganizationCommand : IRequest
    {
        public int organisationid { get; set; }
    }
    public class DeleteMasterCommandHandler : IRequestHandler<DeleteOrganizationCommand>
    {
        private readonly IOrganizationService _iOrganizationService;

        public DeleteMasterCommandHandler(IOrganizationService iOrganizationService)
        {
            _iOrganizationService = iOrganizationService;
        }

        #region "To delete the Organization"
        ///<summary>
        /// Created By Spandana Ray on 14/06/2021
        /// </summary>
        /// <parameter>Request Object of DeleteOrganizationCommand</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To delete the Organization</remarks>
        public async Task<Unit> Handle(DeleteOrganizationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _iOrganizationService.GetOrganizationById(request.organisationid);

            if (entity == null)
            {
                throw new NotFoundException(nameof(OrgRegistration), request.organisationid);
            }
            await _iOrganizationService.DeleteOrganization(request.organisationid);

            return Unit.Value;
        }
        #endregion
    }
}
