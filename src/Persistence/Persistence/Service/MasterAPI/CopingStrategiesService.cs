using Microsoft.EntityFrameworkCore;
using SRIS.Application.AllMaster.CopingStrategiesHouseholdMasterAPI.Queries.GetCopingStrategies;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service.MasterAPI
{
    public class CopingStrategiesService : ICopingStrategiesService
    {
        private readonly IApplicationDbContext _context;

        public CopingStrategiesService(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<CommonCopingStrategiesTypeDto>> GetcopingStrategyData()
        {
            try
            {
                var Lists = await _context.m_master_coping.Where(g => !g.deletedflag)
                .Select(a => new CommonCopingStrategiesTypeDto {
                    id = a.copingid,
                    name = a.copingname,
                    copingytypeid = a.copingtypeid })
                .ToListAsync(); //copingytypeid

                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonCopingStrategiesDto>> GetrestoringData()
        {
            try
            {
                var Lists = await _context.m_master_resortLivelhoodCoping.Where(g => !g.deletedflag)
                .Select(a => new CommonCopingStrategiesDto
                { 
                    id = a.resortlivelyhoodcopingid , 
                    name = a.resortlivelyhoodcoping                
                })
                .ToListAsync();

                return Lists;
            }
            //try
            //{
            //    List<CommonCopingStrategiesDto> lists = new List<CommonCopingStrategiesDto>();
            //    lists.Add(new CommonCopingStrategiesDto { id = 1, name = "Yes, frequently" });
            //    lists.Add(new CommonCopingStrategiesDto { id = 2, name = "Only during the lean period" });
            //    lists.Add(new CommonCopingStrategiesDto { id = 3, name = "Occasionally" });
            //    lists.Add(new CommonCopingStrategiesDto { id = 4, name = "Never" });
            //    return lists;
            //}
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonfoodCopingStrategiesDto>> GetfoodrestoringData()
        {
            try
            {
                var Lists = await _context.m_master_resortfoodCoping.Where(g => !g.deletedflag)
               .Select(a => new CommonfoodCopingStrategiesDto
               {
                   id = a.resortfoodcopingid, 
                   name = a.resortfoodcoping 
               })
               .ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
