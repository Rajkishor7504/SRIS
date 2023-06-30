using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
    public class LastLevelGradeMasterEntity:BaseEntity
    {
        [Key]
        public int lastlevelid { get; set; }
        public string lastlevelname { get; set; }
    }
}
