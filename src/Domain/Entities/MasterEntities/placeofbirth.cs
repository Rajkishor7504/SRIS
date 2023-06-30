using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
  public  class placeofbirth:BaseEntity
    {
        [Key]
        public int birthplaceid { get; set; }
        public string birthplacename { get; set; }

        

    }
}
