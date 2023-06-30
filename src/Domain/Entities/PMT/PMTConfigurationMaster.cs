using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.PMT
{
    public class PMTConfigurationMaster:BaseEntity
    {[Key]
        public int pmtconfigureid { get; set; }
        public string formulaname { get; set; }
        public string formulacode { get; set; }
        public string formuladescription { get; set; }
        public int planid { get; set; }
        public decimal formulaconstant { get; set; }
        
    }
}
