using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
    public class Ismotherliveinhouse : BaseEntity
    {
        [Key]
        public int id { get; set; }
        public string ismotherliveinhouse { get; set; }
        public string description { get; set; }
    }
}
