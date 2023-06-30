using Microsoft.EntityFrameworkCore;
using SRIS.Application.AllMaster.HouseHoldAssetAPI.Queries.GethhAssetMaster;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service.MasterAPI
{
    public class HouseHoldAssetService : IHouseHoldAssetService
    {
        private readonly IApplicationDbContext _context;

        public HouseHoldAssetService(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<AssetMasterDto>> GethhAssetData()
        {
            try
            {
                var Lists = await _context.m_master_medium.Select(a => new AssetMasterDto { id = a.mediumid, 
                    name = a.mediumname }).OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
