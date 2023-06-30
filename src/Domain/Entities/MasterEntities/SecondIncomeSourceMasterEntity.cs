using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
    public class SecondIncomeSourceMasterEntity:BaseEntity
    {
        [Key]
        public int secondincomesourceid { get; set; }
        public string secondincomesourcename { get; set; }
        public string description { get; set; }
    }
}
