using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class MainJobActivity : BaseEntity
    {
        [Key]
        public int activityid { get; set; }
        public string activityname { get; set; }
        public string description { get; set; }
    }   

}
