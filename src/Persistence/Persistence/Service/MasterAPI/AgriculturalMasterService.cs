using Microsoft.EntityFrameworkCore;
using SRIS.Application.AllMaster.AgriculturalMasterAPI.Queries.GetAgricultureMaster;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service.MasterAPI
{
    public class AgriculturalMasterService : IAgriculturalMasterService
    {
        private readonly IApplicationDbContext _context;

        public AgriculturalMasterService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CommonAgricultureMasterDto>> GetBreedingData()
        {
            try
            {
                List<CommonAgricultureMasterDto> lists =  new List<CommonAgricultureMasterDto>();
                lists.Add(new CommonAgricultureMasterDto { id = 1, name = "Male member" });
                lists.Add(new CommonAgricultureMasterDto { id = 2, name = "Female Member" });
                lists.Add(new CommonAgricultureMasterDto { id = 3, name = "People outside the household" });
               
                return lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonAgricultureMasterDto>> GetCropData()
        {
            try
            {
                var Lists = await _context.m_master_crop.Where(g => !g.deletedflag)
                .Select(a => new CommonAgricultureMasterDto { id = a.cropid, name = a.cropname }).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonAgricultureMasterDto>> GetlivestockData()
        {
            try
            {
                var Lists = await _context.m_master_livestock.Where(g => !g.deletedflag)
                .Select(a => new CommonAgricultureMasterDto { id = a.livestockid, name = a.livestockname }).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //added on 22-05-23

        public async Task<List<CommonAgricultureMasterDto>> GetEcologyData()
        {
            try
            {
                var Lists = await _context.m_master_typeofecology.Where(g => !g.deletedflag)
                .Select(a => new CommonAgricultureMasterDto {
                    id = a.type_id,
                    name = a.type_name }).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
