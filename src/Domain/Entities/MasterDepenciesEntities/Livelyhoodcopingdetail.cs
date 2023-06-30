using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterDepenciesEntities
{
    public class Livelyhoodcopingdetail : BaseEntity
    {
        [Key]
        public int intcopingdetailid { get; set; }
        public int intcopingid { get; set; }
    }
}
