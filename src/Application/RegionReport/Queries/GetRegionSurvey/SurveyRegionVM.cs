using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.RegionReport.Queries.GetRegionSurvey
{
   public class SurveyRegionVM
    {
        public SurveyRegionVM()
        {
            Lists = new List<SurveyRegionDto>();
        }
        public IList<SurveyRegionDto> Lists { get; set; }
        public string p_action { get; set; }
        public int surveyplanid { get; set; }
        public string surveyname { get; set; }
        public int splanid { get; set; }
        public string levelname { get; set; }
        public int levelid { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
        public int total_household { get; set; }
        public int approved { get; set; }
        public int reject { get; set; }
        public int pending { get; set; }
        public string hhcode { get; set; }
        public string hhheadname { get; set; }
        //public string Gender { get; set; }
        public string No_of_family_member { get; set; }
        public string address { get; set; }
        public string telephoneno { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }

    }
}
