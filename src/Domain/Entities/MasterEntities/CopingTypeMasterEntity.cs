using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
    public class CopingTypeMasterEntity:BaseEntity
    {
        [Key]
        public int copingtypeid { get; set; }
        public string copingtypename { get; set; }
        public string description { get; set; }
    }
}
