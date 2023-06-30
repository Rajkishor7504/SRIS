using SRIS.Application.Household.DistanceInfo.Queries.GetDistanceInfoQuery;
using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.AllMaster.DistanceMasterAPI.Queries.GetDistanceMaster
{
   public class DistanceMasterVM
    {
        public List<CommonDistanceMasterDto> distanceType { get; set; }
        public List<CommonDistanceMasterDto> services { get; set; }
    }
    public class DistanceMasterResponse : CommonMobileApiStatus
    {
        public DistanceMasterVM distanceMaster { get; set; }
    }
    public class DistanceMasterWebResponse 
    {
        public DistanceMasterResponse Master { get; set; }
        public IList<HouseholdDistance> Lists { get; set; }
        public int hhid { get; set; }
        public string hhno { get; set; }
        public string householdheadname { get; set; }
    }
    }
