using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
    public class ResortFoodCoping:BaseEntity
    {
        [Key]
        public int resortfoodcopingid { get; set; }
        public string resortfoodcoping { get; set; }
        public string description { get; set; }
    }
}
