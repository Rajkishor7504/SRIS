using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class WallCategory : BaseEntity
    {
        [Key]
        public int categoryid { get; set; }
        public string categoryname { get; set; }
       
        //public int createdby { get; set; }
        //public int updatedby { get; set; }
        //public int deletedflag { get; set; }
    }
}


