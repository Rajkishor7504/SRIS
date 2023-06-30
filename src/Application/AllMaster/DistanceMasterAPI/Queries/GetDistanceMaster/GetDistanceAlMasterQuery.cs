
/*
* File Name : GetDistanceAlMasterQuery.cs
* class Name : GetDistanceAlMasterQuery, GetDistanceAlMasterHandler
* Created Date : 16th June 2021
* Created By : Rajalaxmi behera
* Description : Query to get the DistanceAl Master records
*/
using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IMaster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.AllMaster.DistanceMasterAPI.Queries.GetDistanceMaster
{
   public class GetDistanceAlMasterQuery : IRequest<DistanceMasterVM>
    {
        public int id { get; set; }
    }
    public class GetDistanceAlMasterHandler : IRequestHandler<GetDistanceAlMasterQuery, DistanceMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDistanceMasterService _distanceMasterService;

        public GetDistanceAlMasterHandler(IApplicationDbContext context, IMapper mapper, IDistanceMasterService distanceMasterService)
        {
            _context = context;
            _mapper = mapper;
            _distanceMasterService = distanceMasterService;
        }

        #region "To get the Education Master records"

        public async Task<DistanceMasterVM> Handle(GetDistanceAlMasterQuery request, CancellationToken cancellationToken)
        {
            DistanceMasterVM model = new DistanceMasterVM();
            model.distanceType = await _distanceMasterService.GettransportationmodeData();
            model.services = await _distanceMasterService.GetserviceData();
            return model;
        }
        #endregion
    }
}
