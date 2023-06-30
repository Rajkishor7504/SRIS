using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
    public class ConfigureGrievance:BaseEntity
    {[Key]
        public int grievanceconfigid { get; set; }
        public string grievancename { get; set; }
        public string description { get; set; }
        public bool isForward { get; set; }
    }
}
