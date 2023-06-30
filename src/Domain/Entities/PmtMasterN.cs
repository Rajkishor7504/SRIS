using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities
{
    public class PmtMasterN : BaseEntity
    {
        [Key]
        public int categoryid { get; set; }
        public string category { get; set; }
        public Decimal min_value { get; set; }
        public Decimal max_value { get; set; }
    }
}
