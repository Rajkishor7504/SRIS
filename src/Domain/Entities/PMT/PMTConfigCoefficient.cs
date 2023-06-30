using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.PMT
{
    public class PMTConfigCoefficient:BaseEntity
    {[Key]
        public int coefficientid { get; set; }
        public int moduleid { get; set; }
        public int parameterid { get; set; }
        public decimal coefficient { get; set; }
        public decimal constant { get; set; }
        public int pmtconfigureid { get; set; }
        public int yesvalue { get; set; }
        public int novalue { get; set; }
    }
}
