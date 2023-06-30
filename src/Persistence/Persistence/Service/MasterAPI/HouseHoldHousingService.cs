using Microsoft.EntityFrameworkCore;
using SRIS.Application.AllMaster.HouseHoldHousingAPI.Queries.GetHouseHoldHousing;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service.MasterAPI
{
    public class HouseHoldHousingService : IHouseHoldHousingService
    {
        private readonly IApplicationDbContext _context;

        public HouseHoldHousingService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CommonHouseHoldHousingDto>> GetConstructionMaterialData()
        {
            try
            {
                var Lists = await _context.m_master_constrmatcategory.Where(g => !g.deletedflag)
                .Select(a => new CommonHouseHoldHousingDto { id = a.categoryid, name = a.categoryname })
                .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonHouseHoldHousingSubDto>> GetConstructionSubMaterialData()
        {
            try
            {
                var List = await _context.m_master_constrmatcategory.Where(g => !g.deletedflag).ToListAsync();
                var SubLists = await _context.m_master_constrmatsubcategory.Where(g => !g.deletedflag).ToListAsync();
                var Lists = (from a in List
                             join b in SubLists on a.categoryid equals b.categoryid
                             select new CommonHouseHoldHousingSubDto
                             {
                                 categoryid = a.categoryid,
                                 subcategoryid = b.subcategoryid,
                                 name = b.subcategoryname
                             }
                      ).ToList();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
            throw new NotImplementedException();
        }

        public async Task<List<CommonHouseHoldHousingDto>> GetcoockingFuelData()
        {
            try
            {
                var Lists = await _context.m_master_cookingfuel.Where(g => !g.deletedflag)
                .Select(a => new CommonHouseHoldHousingDto { id = a.fuelid, name = a.fuelname })
                .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonHouseHoldHousingDto>> GetdisposeofRubishData()
        {
            try
            {
                var Lists = await _context.m_master_disposerubbish.Where(g => !g.deletedflag)
                .Select(a => new CommonHouseHoldHousingDto { id = a.disposeid, name = a.disposename })
                .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonHouseHoldHousingDto>> GetfloorMaterialData()
        {
            try
            {
                var Lists = await _context.m_master_flooringmaterialcategory.Where(g => !g.deletedflag)
                .Select(a => new CommonHouseHoldHousingDto { id = a.categoryid, name = a.categoryname })
                .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonHouseHoldHousingSubDto>> GetfloorSubMaterialData()
        {


            try
            {
                var List = await _context.m_master_flooringmaterialcategory.Where(g => !g.deletedflag).ToListAsync();
                var SubLists = await _context.m_master_flooringmaterialsubcategory.Where(g => !g.deletedflag).ToListAsync();
                var Lists = (from a in List
                             join b in SubLists on a.categoryid equals b.categoryid
                             select new CommonHouseHoldHousingSubDto
                             {
                                 categoryid = a.categoryid,
                                 subcategoryid = b.subcategoryid,
                                 name = b.subcategoryname
                             }
                      ).ToList();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonHouseHoldHousingDto>> GetmainDrinkingSourceData()
        {
            try
            {
                var Lists = await _context.m_master_drinkingsource.Where(g => !g.deletedflag)
                .Select(a => new CommonHouseHoldHousingDto { id = a.sourceid, name = a.sourcename })
                .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonHouseHoldHousingDto>> GetmainLightingSourceData()
        {
            try
            {
                var Lists = await _context.m_master_lightingsource.Where(g => !g.deletedflag)
                .Select(a => new CommonHouseHoldHousingDto { id = a.sourceid, name = a.sourcename })
                .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonHouseHoldHousingDto>> GetoccupancyStatusData()
        {
            try
            {
                List<CommonHouseHoldHousingDto> lists =   new  List<CommonHouseHoldHousingDto>();
                lists.Add(new  CommonHouseHoldHousingDto  { id=1,name= "Owned" });
                lists.Add(new CommonHouseHoldHousingDto { id = 2, name = "Renting" });
                lists.Add(new CommonHouseHoldHousingDto { id = 3, name = "Dwelling provided rent-free" });               
                return lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public  async Task<List<CommonHouseHoldHousingDto>> GetroofMaterialData()
        {
            try
            {
                var Lists = await _context.m_master_roffingmaterialcategory.Where(g => !g.deletedflag)
                .Select(a => new CommonHouseHoldHousingDto { id = a.categoryid, name = a.categoryname })
                .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonHouseHoldHousingSubDto>> GetroofSubMaterialData()
        {
            try
            {
                var List = await _context.m_master_roffingmaterialcategory.Where(g => !g.deletedflag).ToListAsync();
                var SubLists = await _context.m_master_roffingmaterialsubcategory.Where(g => !g.deletedflag).ToListAsync();
                var Lists = (from a in List
                            join b in SubLists on a.categoryid equals b.categoryid
                            select new CommonHouseHoldHousingSubDto
                            {
                                categoryid = a.categoryid,
                                subcategoryid = b.subcategoryid,
                                name = b.subcategoryname
                            }
                      ).ToList();

                //var Lists = await _context.m_master_roffingmaterialsubcategory.Where(g => !g.deletedflag)
                //.Select(a => new CommonHouseHoldHousingSubDto { categoryid = a.categoryid, name = a.subcategoryname, subcategoryid = a.subcategoryid })
                //.OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonHouseHoldHousingDto>> GettoiletTypeData()
        {
            try
            {
                var Lists = await _context.m_master_toilettype.Where(g => !g.deletedflag)
                .Select(a => new CommonHouseHoldHousingDto { id = a.typeid, name = a.typename })
                .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonHouseHoldHousingDto>> GetwallMaterialData()
        {
            try
            {
                var Lists = await _context.m_master_wallcategory.Where(g => !g.deletedflag)
                .Select(a => new CommonHouseHoldHousingDto { id = a.categoryid, name = a.categoryname })
                .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonHouseHoldHousingSubDto>> GetwallSubMaterialData()
        {
            try
            {
                //var List = await _context.m_master_wallcategory.Where(g => !g.deletedflag).ToListAsync();
                //var SubLists = await _context.m_master_wallsubcategory.Where(g => !g.deletedflag).ToListAsync();

                var List = await _context.m_master_constrmatcategory.Where(g => !g.deletedflag).ToListAsync();
                var SubLists = await _context.m_master_constrmatsubcategory.Where(g => !g.deletedflag).ToListAsync();
                var Lists = (from a in List
                             join b in SubLists on a.categoryid equals b.categoryid
                             select new CommonHouseHoldHousingSubDto
                             {
                                 categoryid = a.categoryid,
                                 subcategoryid = b.subcategoryid,
                                 name = b.subcategoryname
                             }
                      ).ToList();             
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
