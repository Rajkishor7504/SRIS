using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterDepenciesEntities
{
    public class Incomeorgdetail : BaseEntity
    {
        [Key]
        public int detailid { get; set; }
        public int orgtype { get; set; }
       
    }
}
