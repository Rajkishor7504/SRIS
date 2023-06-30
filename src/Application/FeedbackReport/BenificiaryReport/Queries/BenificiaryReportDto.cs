using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.Feedback;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.FeedbackReport.BenificiaryReport.Queries
{
    public class BenificiaryReportDto : IMapFrom<BenificiaryReportf>
    {
        public List<BenificiaryReportDto> Lists { get; set; }
        public string slno { get; set; }

        public int datarequest_id { get; set; }
        public string program_Code { get; set; }
        public string program_Name { get; set; }
        //public string Program_Name { get; set; }
        //public string Program_Code { get; set; }
        public string householdno { get; set; }
        public string action { get; set; }
        public int createdby { get; set; }
        public int regionid { get; set; }
        public int lga { get; set; }
        public int district { get; set; }
        // public int ward { get; set; }
        public int town { get; set; }
        public int districtid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
        public string householdnumber { get; set; }
        public int householdpaid { get; set; }
        public string orgname { get; set; }
        public bool deletedflag { get; set; }
        public int p_id { get; set; }
        public int levelid { get; set; }
        public string levelname { get; set; }
        public int parentid { get; set; }
        public int leveldetailid { get; set; }
        // public int organizationId { get; set; }
        //public int organisationid { get; set; }
        public int programdetailsid { get; set; }

        public int p_hhid { get; set; }

        public int organisationid { get; set; }
        public string organisationname { get; set; }
        public int organizationid { get; set; }
        public int paymentid { get; set; }
        public string benificiaryname { get; set; }
        public string location { get; set; }
        public string paymenttype { get; set; }


        public decimal amounttodate { get; set; }
        public string dateofcashtransefer { get; set; }
        public string datesofactualtransefer { get; set; }
        public string paymentserviceprovider { get; set; }

        public int pageno { get; set; }
        public int pagesize { get; set; }
        public int totalrecords { get; set; }

        public string settlement { get; set; }
        public string districtt { get; set; }
        public string ward { get; set; }

        public string dobofproxy { get; set; }
        public string genderofproxy { get; set; }
        public string proxyrecipientname { get; set; }
        public int programid { get; set; }
        public float amount { get; set; }
        public string benefits { get; set; }

        public int hhid { get; set; }
    }
}
