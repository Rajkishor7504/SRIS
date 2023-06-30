using SRIS.Application.AllMaster.DocumentTypeMaster.Queries.GetDocumentTypeListMaster;
using SRIS.Application.AllMaster.EthnicityMaster.Queries.GetEthnicityListMaster;
using SRIS.Application.MaritalStatusMaster.Queries.GetMaritalStatusListMaster;
using SRIS.Application.AllMaster.NationalityMaster.Queries.GetNationalityListMaster;
using SRIS.Application.RelationMasters.Queries.GetRelationMaster;
using SRIS.Application.ResidenceStatusMaster.Queries.GetResidenceStatusList;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
   public interface IDemographicMasterService
    {
        Task<List<RelationMasterModel>> GetrelationshipData();
        Task<List<ResidenceStatusDto>> GetresidenceStatusData();
        Task<List<NationalityMasterDto>> GetnationalityData();
        Task<List<DocumentTypeMasterDto>> GetdocumentTypeData();
        Task<List<EthnicityMasterDto>> GetethinicityData();
        Task<List<MaritalStatusMasterModel>> GetmaritalStatusData();
        Task<List<PlaceOfBirthDto>> GetplaceOfBirthData();

    }
}
