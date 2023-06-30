using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.LocationMaster.Queries.GetLocationMaster;
using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.LocationMaster.Queries.GetEnumeratorLocation
{
   public class GetEnumeratorLocationQuery : IRequest<EnumerationLocationResponse>
    {
      public  int userid { get; set; }
    }
    public class GetEnumeratorLocationQueryHandler : IRequestHandler<GetEnumeratorLocationQuery, EnumerationLocationResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IEnumeratorLocationMasterServiceCM _locationMasterService;

        public GetEnumeratorLocationQueryHandler(IApplicationDbContext context, IMapper mapper, IEnumeratorLocationMasterServiceCM locationMasterService)
        {
            _context = context;
            _mapper = mapper;
            _locationMasterService = locationMasterService;
        }

        #region "To get the Location Master"
        ///<summary>
        /// Created By Rajalaxmi Behera on 28/09/2021
        /// </summary>
        /// <parameter>Request Object of GetEnumeratorLocationQuery</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To get Enumerator Location records</remarks>
        public async Task<EnumerationLocationResponse> Handle(GetEnumeratorLocationQuery request, CancellationToken cancellationToken)
        {
            EnumerationLocationResponse model = new EnumerationLocationResponse();
            try
            {
                model.surveyPlan = await _locationMasterService.GetEnumerationData("C", request.userid);// For Survey Planning
                model.clusterno = await _locationMasterService.GetClusterNo("CN", model.surveyPlan[0].surveyPlanId); // For Cluster No
                
                LocationMasterVM locationMaster = new LocationMasterVM();
                locationMaster.lgaData = await _locationMasterService.GetClusterLevelData(model.surveyPlan[0].surveyPlanId, model.clusterno[0].clusterno); // For Location 
                locationMaster.districtData = await _locationMasterService.GetClusterDistrictData(model.surveyPlan[0].surveyPlanId, model.clusterno[0].clusterno, locationMaster.lgaData[0].id);// For District
                locationMaster.wardData = await _locationMasterService.GetClusterWardData(model.clusterno[0].clusterno, locationMaster.lgaData[0].id, locationMaster.districtData[0].distId); // For Ward
                locationMaster.settlementData = await _locationMasterService.GetClusterSettlementData(model.clusterno[0].clusterno, locationMaster.lgaData[0].id, locationMaster.districtData[0].distId, locationMaster.wardData[0].id); //For Settlement

                model.enumeratorArea = await _locationMasterService.GetEnumerationEAData(model.clusterno[0].clusterno, locationMaster.lgaData[0].id, locationMaster.districtData[0].distId, locationMaster.wardData[0].id, locationMaster.settlementData[0].id);

                model.locationMaster = locationMaster;
                model.status = MobileApiStatusCode.OK;
                model.message = "OK";
                model.errorMessage = "";
            }
            catch (Exception ex)
            {
                model.status = MobileApiStatusCode.Badrequest;
                model.message = "Bad request";
                model.errorMessage = ex.Message;
            }
            return model;
        }

        #endregion


    }
}
