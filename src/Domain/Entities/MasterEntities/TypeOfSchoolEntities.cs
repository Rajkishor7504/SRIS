using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
    public class TypeOfSchoolEntities:BaseEntity
    {
        [Key]
        public int schooltypeid { get; set; }
        public string typeofschool { get; set; }
        public string description { get; set; }
    }
}
