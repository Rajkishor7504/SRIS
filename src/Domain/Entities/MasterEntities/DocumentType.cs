using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
  public  class DocumentType : BaseEntity
    {
        [Key]
        public int id { get; set; }

        public string documentType { get; set; }

    }
}
