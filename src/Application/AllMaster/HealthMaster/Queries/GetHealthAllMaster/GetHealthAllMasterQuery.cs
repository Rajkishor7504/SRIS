/*
* File Name : GetHealthAllMasterQuery.cs
* class Name : GetHealthAllMasterQuery, GetHealthAllMasterHandler
* Created Date : 16th June 2021
* Created By : Rajalaxmi behera
* Description : Query to get the Health Related All Master records
*/
using AutoMapper;
using MediatR;
using SRIS.Application.AllMaster.HealthMaster.Queries.GetHealthAllMaster;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace SRIS.Application.AllMaster.HealthMaster.Queries.GetHealthAllMaster
{
   public class GetHealthAllMasterQuery : IRequest<HealthMasterVM>
    {
        public int id { get; set; }

    }
    public class GetHealthAllMasterHandler : IRequestHandler<GetHealthAllMasterQuery, HealthMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHealthMasterService _healthMasterService;

        public GetHealthAllMasterHandler(IApplicationDbContext context, IMapper mapper, IHealthMasterService healthMasterService)
        {
            _context = context;
            _mapper = mapper;
            _healthMasterService = healthMasterService;
        }

        #region "To get the Health Master records"

        public async Task<HealthMasterVM> Handle(GetHealthAllMasterQuery request, CancellationToken cancellationToken)
        {
            HealthMasterVM model = new HealthMasterVM();
            model.chronicIllness = await _healthMasterService.GetDiseaseData();
            model.seeingDifficulty = await _healthMasterService.GetSeeingDefficultyData();

            //22-05-23
            model.communicatingDifficulty = await _healthMasterService.GetCommunicatingDefficultyData();
            model.selfcareDifficulty = await _healthMasterService.GetSelfCareDefficultyData();
            model.walkingDifficulty = await _healthMasterService.GetWalkingDefficultyData();
            model.hearingDifficulty = await _healthMasterService.GetHearingDefficultyData();
            model.rememberingDifficulty = await _healthMasterService.GetRememberingDefficultyData();
            return model;
        }
        #endregion
    }
}
