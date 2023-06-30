using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
    public class GrievanceResolutionStatus:BaseEntity
    {[Key]
        public int id { get; set; }
        public string name { get; set; }
        public int registrationid { get; set; }
        public int grievanceconfigid { get; set; }
        public ResolutionStatus status { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}")]
       // public string actiondate { get; set; }
        //public string reopendate { get; set; }
        //public string grievancedescription { get; set; }

    }
}
