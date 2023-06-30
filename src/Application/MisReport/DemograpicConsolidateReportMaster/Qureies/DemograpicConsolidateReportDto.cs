using SRIS.Application.Common.Mappings;
using SRIS.WebUI.Areas.MisReport.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.MisReport.DemograpicConsolidateReportMaster.Qureies
{
    public class DemograpicConsolidateReportDto : IMapFrom<DemograpicConsolidate>
    {
        public List<DemograpicConsolidateReportDto> Lists { get; set; }
        public int consolid { get; set; }
        public int regionid { get; set; }
        public string region { get; set; }
        public int districtid { get; set; }
        public int parentid { get; set; }
        public string district { get; set; }
        public string action { get; set; }
        public int createdby { get; set; }
        public int wardid { get; set; }
        public string ward { get; set; }
        public int settlementid { get; set; }
        public string settlement { get; set; }
        public int totalhousehold { get; set; }
        public int totalmalemember { get; set; }
        public int totalfemalemember { get; set; }
        public int femaleno { get; set; }
        public int othermember { get; set; }
        public bool deletedflag { get; set; }

        public string slno { get; set; }
        public int levelid { get; set; }
        public string levelname { get; set; }
       
        public int leveldetailid { get; set; }
        public int id { get; set; }
        public int p_id { get; set; }

        public int pageno { get; set; }
        public int pagesize { get; set; }
        public int totalrecords { get; set; }


        public int sex { get; set; }
        public string firstname { get; set; }
        public string gender { get; set; } 
        public string dob { get; set; }
        public string membercode { get; set; }
        public string hhcode { get; set; }
        public string hhno { get; set; }
        public int hhid { get; set; }
        public string relationname { get; set; }
        public int p_settlement { get; set; }
        public int town { get; set; }

    }


}
