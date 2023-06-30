using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
    public class Isfatherstillalive : BaseEntity
    {
        [Key]
        public int id { get; set; }
        public string isfatherstillalive { get; set; }
        public string description { get; set; }
    }
}
