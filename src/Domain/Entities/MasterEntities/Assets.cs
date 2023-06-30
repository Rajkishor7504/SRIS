using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
    public class Assets:BaseEntity
    {
        [Key]
    public int assetid { get; set; }
    public string Assetname { get; set; }
    public string description { get; set; }
    }
}
