using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterDepenciesEntities
{
    public class Cultivationresponsibility : BaseEntity
    {
        [Key]
        public int responsibilityid { get; set; }
        public int cropid { get; set; }
    }
}
