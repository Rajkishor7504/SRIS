using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterDepenciesEntities
{
    public class Incomeaiddetail: BaseEntity
    {
        [Key]
        public int aiddetailid { get; set; }
        public int aidid { get; set; }
        public int incomeid { get; set; }
    }
}
