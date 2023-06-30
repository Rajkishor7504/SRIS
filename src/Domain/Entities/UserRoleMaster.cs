using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities
{
   public class UserRoleMaster : BaseEntity
    { 
     [Key]
    public int roleid { get; set; }
    
    public string rolename { get; set; }

    public string description { get; set; }
    //public int createdby { get; set; }
    //    [Required]
    //public int updatedby { get; set; }
    //    [Required]
    //public bool deletedflag { get; set; }
    }
}
