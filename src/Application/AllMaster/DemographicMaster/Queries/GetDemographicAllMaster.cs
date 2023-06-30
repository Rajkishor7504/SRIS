
/*
* File Name : GetDemographicAllMaster.cs
* class Name : GetDemographicAllMaster, GetDemographicAllMasterHandler
* Created Date : 11th June 2021
* Created By : Rajalaxmi
* Description : Query to get the Demographic Related All Master records
*/
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.RelationMasters.Queries.GetRelationMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.AllMaster.DemographicMaster.Queries
{
   public class GetDemographicAllMaster : IRequest<DemographicMasterVM>
    {
        public int id { get; set; }

    }
    public class GetDemographicAllMasterHandler : IRequestHandler<GetDemographicAllMaster, DemographicMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDemographicMasterService _demographicMasterService;

        public GetDemographicAllMasterHandler(IApplicationDbContext context, IMapper mapper, IDemographicMasterService demographicMasterService)
        {
            _context = context;
            _mapper = mapper;
            _demographicMasterService = demographicMasterService;
        }

        #region "To get the Demographic Master records"

        public async Task<DemographicMasterVM> Handle(GetDemographicAllMaster request, CancellationToken cancellationToken)
        {
            DemographicMasterVM model = new DemographicMasterVM();
            model.relationship = await _demographicMasterService.GetrelationshipData();
            model.residenceStatus = await _demographicMasterService.GetresidenceStatusData();
            model.nationality = await _demographicMasterService.GetnationalityData();
            model.documentType = await _demographicMasterService.GetdocumentTypeData();
            model.ethinicity = await _demographicMasterService.GetethinicityData();
            model.maritalStatus = await _demographicMasterService.GetmaritalStatusData();
            model.placeOfBirth = await _demographicMasterService.GetplaceOfBirthData();
            return model;
        }
        #endregion
    }
}
