/*
* File Name : GetLocationMasterQuery.cs
* class Name : GetLocationMasterQuery, GetLocationMasterQueryHandler
* Created Date : 11th June 2021
* Created By : Rajalaxmi behera
* Description : Query to get the Location Related All Master records
*/
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.LocationMaster.Queries.GetLocationMaster
{
   public class GetLocationMasterQuery:IRequest<LocationMasterVM>
    {
        public int id { get; set; }
    }
    public class GetLocationMasterQueryHandler : IRequestHandler<GetLocationMasterQuery,LocationMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILocationMasterService _locationMasterService;

        public GetLocationMasterQueryHandler(IApplicationDbContext context, IMapper mapper, ILocationMasterService locationMasterService)
        {
            _context = context;
            _mapper = mapper;
            _locationMasterService = locationMasterService;
        }

        #region "To get the Location Master"
        ///<summary>
        /// Created By Rajalaxmi Behera on 11/06/2021
        /// </summary>
        /// <parameter>Request Object of GettLocationMasterQuery</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To get the Marital Status records</remarks>
        public async Task<LocationMasterVM> Handle(GetLocationMasterQuery request, CancellationToken cancellationToken)
        {

           LocationMasterVM locationMaster = new LocationMasterVM();          
            locationMaster.lgaData = await _locationMasterService.GetLevelData();
            locationMaster.districtData = await _locationMasterService.GetDistrictData();
            locationMaster.wardData = await _locationMasterService.GetWardData();
            locationMaster.settlementData = await _locationMasterService.GetSettlementData();


            return locationMaster;
        }

        #endregion

       
    }


   
}
