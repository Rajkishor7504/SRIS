using Microsoft.EntityFrameworkCore;
using SRIS.Application.AllMaster.HealthMaster.Queries.GetHealthAllMaster;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service
{
    public class HealthMasterService : IHealthMasterService
    {
        private readonly IApplicationDbContext _context;

        public HealthMasterService(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<CommonHealthMasterDto>> GetDiseaseData()
        {
            try
            {
                var Lists = await _context.m_master_disease.Where(g => !g.deletedflag)
             .Select(a => new CommonHealthMasterDto { id = a.diseaseid, name = a.diseasename })
              .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonHealthMasterDto>> GetSeeingDefficultyData()
        {
            try
            {
                var Lists = await _context.m_master_seeingdifficulty.Where(g => !g.deletedflag)
             .Select(a => new CommonHealthMasterDto { id = a.id, name = a.name })
              .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //newly added on 22-05-23

        public async Task<List<CommonHealthMasterDto>> GetCommunicatingDefficultyData()
        {
            try
            {
                var Lists = await _context.m_master_Communicatingdifficulty.Where(g => !g.deletedflag)
                .Select(a => new CommonHealthMasterDto { id = a.id, name = a.name })
                .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonHealthMasterDto>> GetSelfCareDefficultyData()
        {
            try
            {
                var Lists = await _context.m_master_Selfcareingdifficulty.Where(g => !g.deletedflag)
             .Select(a => new CommonHealthMasterDto { id = a.id, name = a.name })
              .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonHealthMasterDto>> GetWalkingDefficultyData()
        {
            try
            {
                var Lists = await _context.m_master_Walkingdifficulty.Where(g => !g.deletedflag)
             .Select(a => new CommonHealthMasterDto { id = a.id, name = a.name })
              .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonHealthMasterDto>> GetHearingDefficultyData()
        {
            try
            {
                var Lists = await _context.m_master_Hearingdifficulty.Where(g => !g.deletedflag)
             .Select(a => new CommonHealthMasterDto { id = a.id, name = a.name })
              .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonHealthMasterDto>> GetRememberingDefficultyData()
        {
            try
            {
                var Lists = await _context.m_master_Rememberingdifficulty.Where(g => !g.deletedflag)
                .Select(a => new CommonHealthMasterDto { id = a.id, name = a.name })
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
