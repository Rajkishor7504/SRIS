using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.PMT
{
    public class PMTParameterMaster: BaseEntity
    {[Key]
        public int parameterid { get; set; }
        public int planid { get; set; }
        public int moduleid { get; set; }
        public int questionnaireid { get; set; }
        public int pmtmasterid { get; set; }
        public int yesvalue { get; set; }
        public int novalue { get; set; }
       
    }
}
