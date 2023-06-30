using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.PMT
{
    public class ParameterMasterItem: BaseEntity
    {
        [Key]
        public int pmtmasterid { get; set; }
        public string parametername { get; set; }
        public int moduleid { get; set; }
        public int questionnaireid { get; set; }
    }
}
