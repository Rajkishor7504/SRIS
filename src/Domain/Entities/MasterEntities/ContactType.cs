using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
    public class ContactType : BaseEntity
    {
        [Key]
        public int id { get; set; }
        public string Designation { get; set; }
        public string Description { get; set; }
    }
}
