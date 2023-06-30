using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
    public class ReadWriteAnyLanguageMasterEntity:BaseEntity
    {
        [Key]
        public int readwriteid { get; set; }
        public string typeofreadwrite { get; set; }
        public string description { get; set; }
    }
}
