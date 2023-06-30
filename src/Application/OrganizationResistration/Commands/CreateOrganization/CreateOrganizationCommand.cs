/*
* File Name : CreateOrganizationCommand.cs
* class Name : CreateOrganizationCommand, CreateOrganizationCommandHandler
* Created Date : 10 Jun 2021
* Created By : Spandana Ray
* Description : command class to create the Organization
*/

using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.OrganizationResistration.Queries.GetOrganization;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.OrganizationResistration.Commands.CreateOrganization
{
    public class CreateOrganizationCommand : IRequest<int>
    {
        public int organisationid { get; set; }
        public string organisationname { get; set; }
        public int organisationcategoryid { get; set; }
        public string physicallocation { get; set; }
        public string address { get; set; }
        public string mobileno { get; set; }
        public string telephoneno { get; set; }
        public string officialemail { get; set; }
        public string contactname { get; set; }
        public int contacttype { get; set; }
        public string phoneno { get; set; }        
        public string State { get; set; }
        public int status { get; set; }
        public string email { get; set; }
        public int registrationpurpose { get; set; }
    }

    public class CreateOrganizationCommandHandler : IRequestHandler<CreateOrganizationCommand, int>
    {
        private readonly IOrganizationService _iOrganizationService; private readonly IApplicationDbContext _context;

        public CreateOrganizationCommandHandler(IOrganizationService iOrganizationService, IApplicationDbContext context)
        {
            _iOrganizationService = iOrganizationService;
            _context = context;
        }

        #region "To Create a new record for Organization/Partner"
        ///<summary>
        /// Created By Spandana Ray on 10/06/2021
        /// </summary>
        /// <parameter>Request Object of OrganizationVM</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To Create a new record for Organization/Partner</remarks>
        public async Task<int> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var entity1 = new NotificationMasterTable();
            var entity = new OrganizationDto();
            try
            {
                entity.organisationname = request.organisationname;
                entity.organisationcategoryid = request.organisationcategoryid;
                entity.physicallocation = request.physicallocation;
                entity.address = request.address;
                entity.telephoneno = request.telephoneno;
                entity.mobileno = request.mobileno;
                entity.officialemail = request.officialemail;
                entity.contactname = request.contactname;
                entity.contacttype = request.contacttype;
                entity.phoneno = request.phoneno;
                entity.email = request.email;
                entity.State = request.State;                
                entity.status = 0;
                entity.registrationpurpose = request.registrationpurpose;
                entity.organisationid = request.organisationid;
                entity.organisationid = await _iOrganizationService.AddOrganization(entity);
                if (entity.organisationid == 1)
                {
                    var organisationname = request.organisationname;
                    entity.status = 0;
                    entity.organisationname = " The Organisation: " + organisationname + " has been registered,Pending for approval";
                    entity.Secretkey = "/AllMasters/RegistrationRequest/Index";
                    await _iOrganizationService.Partnernotification(entity);

                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return entity.organisationid;
        }
        #endregion
    }
}
