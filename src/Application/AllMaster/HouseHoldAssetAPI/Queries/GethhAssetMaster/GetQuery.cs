using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IMaster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.AllMaster.HouseHoldAssetAPI.Queries.GethhAssetMaster
{
   public class GetQuery : IRequest<AssetMasterVM>
    {
        public int id { get; set; }

    }
    public class GetHouseHoldAssetMasterHandler : IRequestHandler<GetQuery, AssetMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHouseHoldAssetService _houseHoldAssetService;

        public GetHouseHoldAssetMasterHandler(IApplicationDbContext context, IMapper mapper, IHouseHoldAssetService houseHoldAssetService)
        {
            _context = context;
            _mapper = mapper;
            _houseHoldAssetService = houseHoldAssetService;
        }

        #region "To get the Asset Master records"

        public async Task<AssetMasterVM> Handle(GetQuery request, CancellationToken cancellationToken)
        {
            AssetMasterVM model = new AssetMasterVM();
            model.houseHoldAsset = await _houseHoldAssetService.GethhAssetData();           
            return model;
        }
        #endregion
    }
}
