using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.Household;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Application.Household.RegisterHouseholdSurvey.Queries.GetRegisterHouseholdSurvey
{
   public  class RegisterHouseholdSurveyDto:IMapFrom<RegisterHouseholdServey>
    {[Key]
        public int hhid { get; set; }
        public int clusterslno { get; set; }
        public int clusterno { get; set; }
        public int lga { get; set; }
        public int district { get; set; }
        public int ward { get; set; }
        public int town { get; set; }
        public int area { get; set; }
        public string eano { get; set; }
        public int compound_number { get; set; }
        public int hhno { get; set; }
        public DateTime interviewdate { get; set; }
        public string interviewername { get; set; }
        public string supervisorname { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public int isagreeforinterview { get; set; }
        public string telephoneno { get; set; }
        public string telephoneno_1 { get; set; }
        public string telephoneno_2 { get; set; }
        public string address { get; set; }
        public int hhinterviewresult { get; set; }
        public string observations { get; set; }
        public string hhcode { get; set; }
        public int apptypeid { get; set; }
        public string respondentname { get; set; }
        public string hhheadname { get; set; }
        public int verifystatus { get; set; }
        public int approvestatus { get; set; }
        public int spotcheckerstatus { get; set; }
        public int allverifiedstatus { get; set; }
        public int allapprovedstatus { get; set; }
        public int lockstatus { get; set; }
        public int surveyplanid { get; set; }
        public DateTime createdon { get; set; }
        public int? updatedby { get; set; }
        public DateTime? updatedon { get; set; }
        public bool deletedflag { get; set; }
    }
}
