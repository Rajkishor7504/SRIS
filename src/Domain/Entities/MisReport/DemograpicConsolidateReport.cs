using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRIS.WebUI.Areas.MisReport.Model
{
    public class DemograpicConsolidate
    {
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
        public string lastname { get; set; }
        public int hhno { get; set; }
        public int hhid { get; set; }
        public int p_settlement { get; set; }
        public string relationname { get; set; }
        public int town { get; set; }

    }
}
