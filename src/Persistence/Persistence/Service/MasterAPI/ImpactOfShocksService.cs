using Microsoft.EntityFrameworkCore;
using SRIS.Application.AllMaster.ImpactOfShocksMasterAPI.Queries.GetImpactOfShocks;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service.MasterAPI
{
    public class ImpactOfShocksService : IImpactOfShocksService
    {
        private readonly IApplicationDbContext _context;

        public ImpactOfShocksService(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<CommonImpactOfShocksDto>> GetlivelihoodData()
        {
            try
            {
                var Lists = await _context.m_master_livelihood.Where(g => !g.deletedflag)
             .Select(a => new CommonImpactOfShocksDto { id = a.livelihoodid, name = a.livelihoodname })
              .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonImpactOfShocksDto>> GetSeverityTypeData()
        {
            try
            {
                List<CommonImpactOfShocksDto> lists = new List<CommonImpactOfShocksDto>();
                lists.Add(new CommonImpactOfShocksDto { id = 1, name = "Very severe" });
                lists.Add(new CommonImpactOfShocksDto { id = 2, name = "Severe" });
                lists.Add(new CommonImpactOfShocksDto { id = 3, name = "Mild / moderate" });
                return lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonImpactOfShocksDto>> GetShocksData()
        {
            try
            {
                var Lists = await _context.m_master_shocks.Where(g => !g.deletedflag)
             .Select(a => new CommonImpactOfShocksDto { id = a.shockid, name = a.shockname })
              .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        
    }
}
