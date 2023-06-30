using Microsoft.EntityFrameworkCore;
using SRIS.Application.AllMaster.DocumentTypeMaster.Queries.GetDocumentTypeListMaster;
using SRIS.Application.AllMaster.EthnicityMaster.Queries.GetEthnicityListMaster;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.MaritalStatusMaster.Queries.GetMaritalStatusListMaster;
using SRIS.Application.AllMaster.NationalityMaster.Queries.GetNationalityListMaster;
using SRIS.Application.RelationMasters.Queries.GetRelationMaster;
using SRIS.Application.ResidenceStatusMaster.Queries.GetResidenceStatusList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service
{
    public class DemographicMasterService : IDemographicMasterService
    {
        private readonly IApplicationDbContext _context;

        public DemographicMasterService(IApplicationDbContext context)
        {
            _context = context;
        }
       public async Task<List<DocumentTypeMasterDto>> GetdocumentTypeData()
        {
            try
            {
                var Lists = await _context.m_master_documentType.Where(g => !g.deletedflag)
              .Select(a => new DocumentTypeMasterDto { id = a.id, name = a.documentType })
               .OrderBy(t => t.name).ToListAsync();
                return Lists;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public async Task<List<EthnicityMasterDto>> GetethinicityData()
        {
            try
            {
                var Lists = await _context.m_master_ethnicity.Where(g => !g.deletedflag)
            .Select(a => new EthnicityMasterDto { id = a.ethnicityid, name = a.ethnicityname })
             .OrderBy(t => t.name)
             .ToListAsync();
             return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<MaritalStatusMasterModel>> GetmaritalStatusData()
        {
            try
            {
                var Lists = await _context.m_master_maritalstatus.Where(g => !g.deletedflag)
            .Select(a => new MaritalStatusMasterModel { id = a.maritalstatusid, name = a.maritalstatusname })
             .OrderBy(t => t.name)
             .ToListAsync();
            return Lists;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public async  Task<List<NationalityMasterDto>> GetnationalityData()
        {
            try
            {
                var Lists = await _context.m_master_nationality.Where(g => !g.deletedflag)
             .Select(a => new NationalityMasterDto { id = a.nationalityid, name = a.nationality })
              .OrderBy(t => t.name)
              .ToListAsync();
            return Lists;
           }
            catch (Exception e)
            {
                return null;
            }
      }

      

        public async Task<List<RelationMasterModel>> GetrelationshipData()
        {
            try
            {
                var Lists = await _context.m_master_relation.Where(g => !g.deletedflag)
             .Select(a => new RelationMasterModel { id = a.id, name = a.relationname })
              .OrderBy(t => t.name)
              .ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<ResidenceStatusDto>> GetresidenceStatusData()
        {
            try
            {
                var Lists = await _context.m_master_residencestatus.Where(g => !g.deletedflag)
             .Select(a => new ResidenceStatusDto { id = a.residencestatusid, name = a.residencestatusname })
              .OrderBy(t => t.name)
              .ToListAsync();
                return Lists;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<PlaceOfBirthDto>> GetplaceOfBirthData()
        {
            try
            {
               var Lists = await _context.m_master_placeofbirth.Where(g => !g.deletedflag)
             .Select(a => new PlaceOfBirthDto { id = a.birthplaceid, name = a.birthplacename })
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
