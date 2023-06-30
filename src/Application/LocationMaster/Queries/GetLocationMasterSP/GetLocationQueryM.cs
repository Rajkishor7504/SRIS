using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.LocationMaster.Queries.GetLocationMaster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.LocationMaster.Queries.GetLocationMasterSP
{
   public class GetLocationQueryM: IRequest<LocationMasterVM>
    {
    }
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQueryM, LocationMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILocationMasterServiceM _locationMasterService;

        public GetLocationQueryHandler(IApplicationDbContext context, IMapper mapper, ILocationMasterServiceM locationMasterService)
        {
            _context = context;
            _mapper = mapper;
            _locationMasterService = locationMasterService;
        }

        #region "To get the Location Master"
        ///<summary>
        /// Created By Rajalaxmi Behera on 24/09/2021
        /// </summary>
        /// <parameter>Request Object of GettLocationMasterQuery</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To get the Marital Status records</remarks>
        public async Task<LocationMasterVM> Handle(GetLocationQueryM request, CancellationToken cancellationToken)
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
