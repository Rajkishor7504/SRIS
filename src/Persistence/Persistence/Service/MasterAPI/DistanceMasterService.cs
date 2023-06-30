using Microsoft.EntityFrameworkCore;
using SRIS.Application.AllMaster.DistanceMasterAPI.Queries.GetDistanceMaster;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service.MasterAPI
{
    public class DistanceMasterService : IDistanceMasterService
    {
        private readonly IApplicationDbContext _context;

        public DistanceMasterService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CommonDistanceMasterDto>> GetserviceData()
        {
            try
            {
                var Lists = await _context.m_master_services.Where(g => !g.deleteflag)
                .Select(a => new CommonDistanceMasterDto { id = a.serviceid, name = a.servicename })
                .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonDistanceMasterDto>> GettransportationmodeData()
        {
            try
            {
                var Lists = await _context.m_master_transportationmode.Where(g => !g.deletedflag)
             .Select(a => new CommonDistanceMasterDto { id = a.modeid, name = a.modename })
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
