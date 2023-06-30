using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities
{
    public class PMTMaster : BaseEntity
    {
        [Key]
        //public int pmtid { get; set; }
        public int categoryid { get; set; }
        public string category { get; set; }
        public int topcutoff { get; set; }
        public int buttomcutoff { get; set; }
        public int pmtid { get; set; }
        public int min_value { get; set; }
        public int max_value { get; set; }
       

    }
}
