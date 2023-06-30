using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities
{
       public class GlobalLinkSlNoMaster
       {
        [Key]
        public int glinkid { get; set; }

        public string glinkname { get; set; }
        public string controllername { get; set; }
        public string actionname { get; set; }
        public string areaname { get; set; }
   
        public int createdby { get; set; }

        public int updatedby { get; set; }
      
        public bool deletedflag { get; set; }
        public int gslno { get; set; }
       }
}
