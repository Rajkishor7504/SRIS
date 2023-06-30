using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class ResidenceStatus : BaseEntity
    {
        [Key]
        public int residencestatusid { get; set; }

        public string residencestatusname { get; set; }
       
    }
}
