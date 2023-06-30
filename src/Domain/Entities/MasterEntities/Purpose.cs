using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
    public class Purpose : BaseEntity
    {
        [Key]
        public int purposeid { get; set; }
        public string purposename { get; set; }
        public string description { get; set; }
    }
}
