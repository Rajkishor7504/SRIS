using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class RelationsToProjectMaster : BaseEntity
    {
        [Key]
        public int relationid { get; set; }
        public string relationname { get; set; }
        public string description { get; set; }
    }
}
