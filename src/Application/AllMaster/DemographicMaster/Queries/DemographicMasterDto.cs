using SRIS.Application.AllMaster.DocumentTypeMaster.Queries.GetDocumentTypeListMaster;
using SRIS.Application.AllMaster.EthnicityMaster.Queries.GetEthnicityListMaster;
using SRIS.Application.MaritalStatusMaster.Queries.GetMaritalStatusListMaster;
using SRIS.Application.AllMaster.NationalityMaster.Queries.GetNationalityListMaster;
using SRIS.Application.RelationMasters.Queries.GetRelationMaster;
using SRIS.Application.ResidenceStatusMaster.Queries.GetResidenceStatusList;
using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.AllMaster.DemographicMaster.Queries
{
   public class DemographicMasterDto
    {
        

    }
    public class DemographicMasterVM 
    {
        public List<RelationMasterModel> relationship { get; set; }
        public List<ResidenceStatusDto> residenceStatus { get; set; }
        public List<NationalityMasterDto> nationality { get; set; }
        public List<DocumentTypeMasterDto> documentType { get; set; }
        public List<EthnicityMasterDto> ethinicity { get; set; }
        public List<MaritalStatusMasterModel> maritalStatus { get; set; }
        public List<PlaceOfBirthDto> placeOfBirth { get; set; }


    }
    public class DemographicMasterResponse : CommonMobileApiStatus
        {
         public DemographicMasterVM demographicMaster { get; set; }
    }
    }
