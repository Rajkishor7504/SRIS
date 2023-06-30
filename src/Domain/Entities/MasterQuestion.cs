using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities
{
    public class MasterQuestion: BaseEntity
    {[Key]
   
        public int questionnaireid { get; set; }
        public string questionnairename { get; set; }
        public int moduleid { get; set; }
    }
}
