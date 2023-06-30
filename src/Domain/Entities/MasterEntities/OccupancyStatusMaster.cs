using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities
{
    public class OccupancyStatusMaster : BaseEntity
    {
        [Key]
        public int id { get; set; }
        public string occupancyStatusName { get; set; }
       
        public string description { get; set; }
       
    }
}
