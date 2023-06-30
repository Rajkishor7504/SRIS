using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class Nationality : BaseEntity
    {

        [Key]
        public int nationalityid { get; set; }
        public string nationality { get; set; }
    }
}
