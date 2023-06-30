using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
    public class NeverAttendSchool : BaseEntity
    {
        [Key]
        public int neverattendschoolid { get; set; }
        public string neverattendschoolname { get; set; }
    }
 }


