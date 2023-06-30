using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
  public  class Grade : BaseEntity
    {
        [Key]
        public int gradeid { get; set; }
        public string gradename { get; set; }
    }   

}
