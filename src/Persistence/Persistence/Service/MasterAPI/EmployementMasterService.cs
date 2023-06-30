using Microsoft.EntityFrameworkCore;
using SRIS.Application.AllMaster.EmployementMasterAPI.Queries.GetEmployeementAllMaster;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service.MasterAPI
{
    public class EmployementMasterService : IEmployementMasterService
    {
        private readonly IApplicationDbContext _context;

        public EmployementMasterService(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<CommonEmployementMasterDto>> GetmainJobActiviyData()
        {
            try
            {
                var Lists = await _context.m_master_mainjobactivity.Where(g => !g.deletedflag)
             .Select(a => new CommonEmployementMasterDto { id = a.activityid, name = a.activityname })
              .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonEmployementMasterDto>> GetnotWorkingReasonData()
        {
            try
            {
                var Lists = await _context.m_master_reasonfornotworking.Where(g => !g.deletedflag)
             .Select(a => new CommonEmployementMasterDto { id = a.reasonid, name = a.reasonname })
              .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonEmployementMasterDto>> GetworkingFrequencyData()
        {
            try
            {
                var Lists = await _context.m_master_workingfreequency.Where(g => !g.deletedflag)
             .Select(a => new CommonEmployementMasterDto { id = a.id, name = a.name })
              .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonEmployementMasterDto>> GetworkingSectorData()
        {
            try
            {
                var Lists = await _context.m_master_workingsector.Where(g => !g.deletedflag)
             .Select(a => new CommonEmployementMasterDto { id = a.sectorid, name = a.sectorname })
              .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonEmployementMasterDto>> GetworkingStatusData()
        {
            try
            {
                var Lists = await _context.m_master_workingstatus.Where(g => !g.deletedflag)
             .Select(a => new CommonEmployementMasterDto { id = a.statusid, name = a.statusname })
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
