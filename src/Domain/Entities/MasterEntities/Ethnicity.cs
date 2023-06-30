using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
  public  class Ethnicity : BaseEntity
    {
        [Key]
        public int ethnicityid { get; set; }

        public string ethnicityname { get; set; }      


    }
}
