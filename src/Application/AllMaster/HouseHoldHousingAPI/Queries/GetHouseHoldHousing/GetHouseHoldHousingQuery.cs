/*
* File Name : GetHouseHoldHousingQuery.cs
* class Name : GetHouseHoldHousingQuery, GetHouseHoldHousingMasterHandler
* Created Date : 17th June 2021
* Created By : Rajalaxmi behera
* Description : Query to get the HouseHold Housing Related All Master records
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

namespace SRIS.Application.AllMaster.HouseHoldHousingAPI.Queries.GetHouseHoldHousing
{
   public class GetHouseHoldHousingQuery : IRequest<HouseHoldHousingVM>
    {
        
    }
    public class GetHouseHoldHousingMasterHandler : IRequestHandler<GetHouseHoldHousingQuery, HouseHoldHousingVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHouseHoldHousingService _houseHoldHousingService;

        public GetHouseHoldHousingMasterHandler(IApplicationDbContext context, IMapper mapper, IHouseHoldHousingService houseHoldHousingService)
        {
            _context = context;
            _mapper = mapper;
            _houseHoldHousingService = houseHoldHousingService;
        }

        #region "To get the household  All Master records"

        public async Task<HouseHoldHousingVM> Handle(GetHouseHoldHousingQuery request, CancellationToken cancellationToken)
        {
            HouseHoldHousingVM model = new HouseHoldHousingVM();
            model.occupancyStatus = await _houseHoldHousingService.GetoccupancyStatusData();
            model.wallMaterial = await _houseHoldHousingService.GetwallMaterialData();
            model.wallSubMaterial = await _houseHoldHousingService.GetwallSubMaterialData();
            model.floorMaterial = await _houseHoldHousingService.GetfloorMaterialData();
            model.floorSubMaterial = await _houseHoldHousingService.GetfloorSubMaterialData();
            model.roofMaterial = await _houseHoldHousingService.GetroofMaterialData();
            model.roofSubMaterial = await _houseHoldHousingService.GetroofSubMaterialData();
            model.mainLightingSource = await _houseHoldHousingService.GetmainLightingSourceData();
            model.coockingFuel = await _houseHoldHousingService.GetcoockingFuelData();
            model.toiletType = await _houseHoldHousingService.GettoiletTypeData();
            model.mainDrinkingSource = await _houseHoldHousingService.GetmainDrinkingSourceData();
            model.disposeofRubish = await _houseHoldHousingService.GetdisposeofRubishData();
            model.constructionMaterial = await _houseHoldHousingService.GetConstructionMaterialData();
            model.constructionSubMaterial = await _houseHoldHousingService.GetConstructionSubMaterialData();
            return model;
        }
        #endregion
    }
}
