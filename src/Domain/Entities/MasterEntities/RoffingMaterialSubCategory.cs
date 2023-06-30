using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
  public  class RoffingMaterialSubCategory : BaseEntity
    {
        [Key]
        public int subcategoryid { get; set; }
        public int categoryid { get; set; }
        public string subcategoryname { get; set; }
    }
}
