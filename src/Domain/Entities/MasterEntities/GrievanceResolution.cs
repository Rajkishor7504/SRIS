using System;
using System.ComponentModel.DataAnnotations;

namespace SRIS.Domain.Entities.MasterEntities
{
    public class GrievanceResolution:BaseEntity
    {[Key]
        public int id { get; set; }
        public string name { get; set; }
        public int registrationid { get; set; }
        public int grievanceconfigid { get; set; }
        public ResolutionStatus status { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}")]
        public DateTime? actiondate { get; set; }
        public DateTime? reopendate { get; set; }
        public string grievancedescription { get; set; }

    }
}
