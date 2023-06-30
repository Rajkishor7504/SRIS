using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class MainIncomeSource : BaseEntity
    {
        [Key]
        public int incomesourceid { get; set; }
        public string incomesourcename { get; set; }

        public string description { get; set; }
    }
}
