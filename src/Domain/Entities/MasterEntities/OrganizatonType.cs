using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
  public  class OrganizatonType : BaseEntity
    {
        [Key]
        public int organizationtypeid { get; set; }
        public string organizationtypename { get; set; }
        public string description { get; set; }

    }
}

