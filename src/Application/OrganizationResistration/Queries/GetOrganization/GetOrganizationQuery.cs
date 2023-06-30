/*
* File Name : GetOrganizationQuery.cs
* class Name : GetOrganizationQuery
* Created Date : 10 Jun 2021
* Created By : Spandana Ray
* Description : Query to get the organization records
*/

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.OrganizationResistration.Queries.GetOrganization
{
    public class GetOrganizationQuery : IRequest<OrganizationVM>
    {
    }    
    public class GetMyUserQueryHandler : IRequestHandler<GetOrganizationQuery, OrganizationVM>
    {
        private readonly IOrganizationService _iOrganizationService;
        private readonly IMapper _mapper;

        public GetMyUserQueryHandler(IOrganizationService iOrganizationService, IMapper mapper)
        {
            _iOrganizationService = iOrganizationService;
            _mapper = mapper;
        }
        #region "To get the organization records"
        ///<summary>
        /// Created By Spandana Ray on 10/06/2021
        /// </summary>
        /// <parameter>Request Object of GetOrganizationQuery</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To get the organization records</remarks>
        public async Task<OrganizationVM> Handle(GetOrganizationQuery request, CancellationToken cancellationToken)
        {
            return new OrganizationVM
            {
               Lists = await _iOrganizationService.GetOrganization()
            };
        }
        #endregion
    }
}
