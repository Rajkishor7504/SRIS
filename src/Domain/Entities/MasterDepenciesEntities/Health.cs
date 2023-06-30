using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterDepenciesEntities
{
    public class Health : BaseEntity
    {
        [Key]
        public int d05a_dohavediffwearingglass { get; set; }
    }
}
