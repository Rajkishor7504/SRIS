using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
    public class Isfatherliveinhouse : BaseEntity
    {
        [Key]
        public int id { get; set; }
        public string isfatherliveinhouse { get; set; }
        public string description { get; set; }
    }
}
