using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class LevelMaster: BaseEntity
    {
        [Key]
        public int levelid { get; set; }
        public string levelname { get; set; }        
    }
}
