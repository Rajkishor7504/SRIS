using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.SurveyPlanning.EnumerationArea.Query
{
   public class EnumerationAreaVM: CommonMobileApiStatus
    {
        public EnumerationAreaVM()
        {
            list = new List<EnumerationAreaModel>();
        }
        public List<EnumerationAreaModel> list { get; set; }
    }
    public class EnumerationAreaModel
    {
        //for basic
        public int id { get; set; }
        public string name { get; set; }
        public string typeid { get; set; }
        // 1st table
        public int surveyplanid { get; set; }
        public string surveyplan { get; set; }
        public int eaid { get; set; }
        public string eaname { get; set; }
        public int teamid { get; set; }
       

        // 2nd table
        public int regionid { get; set; }
        public int districtid { get; set; }
        public int settlementid { get; set; }
        public int wardid { get; set; }
        public int clusterno { get; set; }

        public string lgaName { get; set; }
        public string districtName { get; set; }
        public string settlementName { get; set; }
        public string wardName { get; set; }
        public string multidistrictid { get; set; }
        public string multisettlementid { get; set; }
        public List<EnumerationAreaModel> list { get; set; }

    }
}
