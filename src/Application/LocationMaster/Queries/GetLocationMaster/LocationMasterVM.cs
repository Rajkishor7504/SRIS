using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.LocationMaster.Queries.GetLocationMaster
{
   public class LocationMasterVM
    {
        //public LocationMasterResponse locationMaster { get; set; }
        public IList<lgaDto> lgaData { get; set; }
        public IList<DistrictDto> districtData { get; set; }
        public IList<WardDto> wardData { get; set; }
        public IList<SettlementDto> settlementData { get; set; }
    }
    public class LocationMasterResponse: CommonMobileApiStatus
    {
        public LocationMasterVM locationMaster { get; set; }
       
    }
    public class EnumerationLocationResponse : CommonMobileApiStatus
    {
        public List<EnumerationSurveyPlan> surveyPlan { get; set; }
        public List<ClusterNumber> clusterno { get; set; }
        public List<EnumerationEAModel> enumeratorArea { get; set; }
        public LocationMasterVM locationMaster { get; set; }
    }
    public class ClusterNumber
    {
        public int planid { get; set; }
        public int clusterno { get; set; }

    }
    public class EnumerationSurveyPlan
    {
        public int surveyPlanId { get; set; }
        public string surveyPlanName { get; set; }
       
    }
    public class EnumerationEAModel
    {
        public int eaid { get; set; }
        public string eanumber { get; set; }
        public int surveyPlanId { get; set; }
    }
}
