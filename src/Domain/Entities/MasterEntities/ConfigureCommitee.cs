using SRIS.Domain.Common;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
    public class ConfigureCommitee: BaseEntity
    {
        [Key]
        public int configureid { get; set; }
        [Required(ErrorMessage ="Commitee Name is required")]
        public string commiteename { get; set; }
        [Required(ErrorMessage = "No of commitee member is required")]
        public int noofcommiteemembers { get; set; }
        

       
       

    }
}
