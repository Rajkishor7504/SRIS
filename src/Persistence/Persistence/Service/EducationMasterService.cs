using Microsoft.EntityFrameworkCore;
using SRIS.Application.AllMaster.EducationMaster.Queries;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service
{
   public class EducationMasterService: IEducationMasterService
    {
        private readonly IApplicationDbContext _context;

        public EducationMasterService(IApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<List<CommonEducationMasterDto>> GetGradeData()
        {
            try
            {
                var Lists = await _context.m_master_grade.Where(g => !g.deletedflag)
             .Select(a => new CommonEducationMasterDto { id = a.gradeid, name = a.gradename })
              .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonEducationMasterDto>> GetNeverAttendSchoolData()
        {
            try
            {
                var Lists = await _context.m_master_reasonforneverattendschool.Where(g => !g.deletedflag)
             .Select(a => new CommonEducationMasterDto { id = a.reasonid, name = a.reason })
              .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonEducationMasterDto>> GetReasonForStopSchoolData()
        {
            try
            {
                var Lists = await _context.m_master_reasonforstopschool.Where(g => !g.deletedflag)
             .Select(a => new CommonEducationMasterDto { id = a.reasonid, name = a.reason })
              .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        //Added on 22-05-2023   
       
        public async Task<List<CommonEducationMasterDto>> GetTypeOfSchoolAttendedData()
        {
            try
            {
                var Lists = await _context.m_master_Schooltype.Where(g => !g.deletedflag)
                .Select(a => new CommonEducationMasterDto {
                    id = a.schooltypeid, 
                    name = a.typeofschool })
                .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonEducationMasterDto>> GetLevelCompletedData()
        {
            try
            {
                var Lists = await _context.m_master_lastlevelgrade.Where(g => !g.deletedflag)
                .Select(a => new CommonEducationMasterDto { id = a.lastlevelid, name = a.lastlevelname })
                .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<CommonEducationMasterDto>> GetTypeOfReadWriteData()
        {
            try
            {
                var Lists = await _context.m_master_readwriteanylanguage.Where(g => !g.deletedflag)
                .Select(a => new CommonEducationMasterDto { 
                    id = a.readwriteid, 
                    name = a.typeofreadwrite
                })
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
