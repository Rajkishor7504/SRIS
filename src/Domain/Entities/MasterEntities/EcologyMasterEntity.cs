using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class EcologyMasterEntity:BaseEntity
    {
        [Key]
        public int type_id { get; set; }
        public string type_name { get; set; }
    }
}
