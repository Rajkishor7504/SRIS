using System.ComponentModel.DataAnnotations;

namespace SRIS.Application.PMT.PMTExecution.Queries.GetPMTResult
{
    public class PMTResultDto
    {
        public int resultid { get; set; }
        public int hhid { get; set; }
        public int pmtconfigureid { get; set; }
        public double pmtscore { get; set; }
        public double Logpmtscore { get; set; }
        public int hhstatus { get; set; }
        public int hhno { get; set; }
        public string hhcode { get; set; }
        public string locationid { get; set; }
        //public int locationid { get; set; }
        public string hhcategory { get; set; }
        public string hhname { get; set; }
        public string PMThhstatus { get; set; }
        public string address { get; set; }
        public string phoneno { get; set; }
        

    }
    public class PMTResultParameterDto
    {
        public int resultid { get; set; }
        public int moduleid { get; set; }
        public int parameterid { get; set; }
        public int questionnaireid { get; set; }
        public int pmtmasterid { get; set; }
        public int? yesvalue { get; set; }
        public int? novalue { get; set; }
        public double coefficient { get; set; }
        public double constant { get; set; }
        public double hhvalue { get; set; }
        public double formulaconstant { get; set; }

        public double Logpmtscore { get; set; }
    public string parametername { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.000}")]
        public double formulavalue
        {
            get
            {
                if(yesvalue==null && novalue == null)
                {
                    var val = hhvalue * coefficient * constant;
                    return val == -0 ? 0 : val;
                }
                else
                {
                    var val= (hhvalue == 1 ? yesvalue.Value : novalue.Value) * coefficient * constant;
                    return val == -0 ? 0 : val;
                }
                
            }

        }
        public string hhstatus { get; set; }
        public string surveyname { get; set; }
        public string formulaname { get; set; }
        public string regionname { get; set; }
        public string districtname { get; set; }
        public string wardname { get; set; }
        public string settlementname { get; set; }
        public string hhno { get; set; }
        public string hhname { get; set; }
        public string category { get; set; }
        public string hhcode { get; set; }
        public string address { get; set; }
        public string phoneno { get; set; }
    }
    public class PMTCategoryWiseCountDto
    {        
        public int pmtconfigureid { get; set; }
        public int HouseholdCount { get; set; }
        public int ExtremelypoorCount { get; set; }
        public int NonpoorCount { get; set; }
        public int PoorCount { get; set; }
        public string locationid { get; set; }
        //public int locationid { get; set; }
        public int ApproveHHCount { get; set; }
        public int TotalReghousehold { get; set; }
        public int ActiontakenHHCount { get; set; }
        public int surveyid { get; set; }



    }
    public class PMTReportWiseCountDto
    {
        public int pmtconfigureid { get; set; }
        public int HouseholdCount { get; set; }
        public int ExtremelypoorCount { get; set; }
        public int NonpoorCount { get; set; }
        public int PoorCount { get; set; }
        public string locationid { get; set; }
        //public int locationid { get; set; }

        public int TotalReghousehold { get; set; }
        public int ApproveHHCount { get; set; }
        public int ExecuteHHCount { get; set; }
        public int surveyid { get; set; }



    }
}
