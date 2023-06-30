using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class FlooringMaterialCategory : BaseEntity
    {
        [Key]
        public int categoryid { get; set; }
        public string categoryname { get; set; }
    }  

}
