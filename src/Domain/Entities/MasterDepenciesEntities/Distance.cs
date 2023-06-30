using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterDepenciesEntities
{
   public class Distance : BaseEntity
    {
        [Key]
        public int transportationmodeid { get; set; }
    }
}
