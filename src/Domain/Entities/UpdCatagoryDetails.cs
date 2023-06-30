using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities
{
   public class UpdCatagoryDetails:BaseEntity
    {[Key]
        public int updcatagorydetailsid { get; set; }
        public int requestid { get; set; }
        public int updatecategoryid { get; set; }
    }
}
