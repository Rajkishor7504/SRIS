using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities
{
    public class MasterModule: BaseEntity
    {[Key]
    public int moduleid { get; set; }
    public string  modulename { get; set; }
    }
}
