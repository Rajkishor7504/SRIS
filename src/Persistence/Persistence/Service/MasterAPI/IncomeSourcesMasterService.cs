using Microsoft.EntityFrameworkCore;
using SRIS.Application.AllMaster.IncomeSourceAPI.Queries.GetIncomeSourceAllMaster;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service.MasterAPI
{
    public class IncomeSourcesMasterService : IIncomeSourcesMasterService
    {
        private readonly IApplicationDbContext _context;

        public IncomeSourcesMasterService(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<CommonIncomeSourceDto>> GetaidFrequencyData()
        {
            try
            {
                var Lists = await _context.m_master_aid_freequency.Where(g => !g.deletedflag)
             .Select(a => new CommonIncomeSourceDto { id = a.id, name = a.name })
              .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonIncomeSourceDto>> GetaidTypeData()
        {
            try
            {
                var Lists = await _context.m_hhr_aid.Where(g => !g.deletedflag)
             .Select(a => new CommonIncomeSourceDto { id = a.aidid, name = a.aidname }) .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonIncomeSourceDto>> GetmainIncomeSourceData()
        {
            try
            {
                var Lists = await _context.m_master_incomesource.Where(g => !g.deletedflag)
             .Select(a => new CommonIncomeSourceDto { id = a.incomesourceid, name = a.incomesourcename }).OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonIncomeSourceDto>> GetorgTypeData()
        {
            try
            {
                var Lists = await _context.m_master_organizatontype.Where(g => !g.deletedflag)
             .Select(a => new CommonIncomeSourceDto { id = a.organizationtypeid, name = a.organizationtypename }).OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonIncomeSourceDto>> GetsecondIncomeSourceData()
        {
            try
            {
                var Lists = await _context.m_master_second_incomesource.Where(g => !g.deletedflag)
             .Select(a => new CommonIncomeSourceDto {
                 id = a.secondincomesourceid,
                 name = a.secondincomesourcename }).OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
