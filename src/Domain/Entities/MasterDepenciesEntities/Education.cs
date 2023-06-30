using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterDepenciesEntities
{
   public class Education : BaseEntity
    {
        [Key]
        public int educationid { get; set; }
        public int memberid { get; set; }
        public int hhid { get; set; }
        public int c06_grade { get; set; }
        public int c08_whystoppedgoingschool { get; set; }
        public int c04_whyneverattendedschool { get; set; }
    }
}