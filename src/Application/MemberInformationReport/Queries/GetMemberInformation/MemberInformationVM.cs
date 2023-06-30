using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.MemberInformationReport.Queries.GetMemberInformation
{
  public  class MemberInformationVM
    {
        public MemberInformationVM()
        {
            Lists = new List<MemberInformationDto>();
        }
        public IList<MemberInformationDto> Lists { get; set; }
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

        public int hhid { get; set; }
        public string hhno { get; set; }
        public string hhname { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public string contactno { get; set; }
        public int totalmember { get; set; }

        //Indivisual member(start)
        public string membername { get; set; }
        public string membercode { get; set; }
        public string gender_m { get; set; }
        public string dob { get; set; }
        public string relationname { get; set; }
        public string nationality { get; set; }
        public string maritalstatusname { get; set; }
        public string residencestatusname { get; set; }
        public string hhcode { get; set; } // added by Deepak(17-11-2022)
        //Indivisual member(end)
    }
}
