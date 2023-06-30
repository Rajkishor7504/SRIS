using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities
{
   public class AssignLinkToRoleMaster
    {
        [Key]
     
        public int linkaccessid { get; set; }
        [Required]
        public int plinkid { get; set; }
        [Required]
        public int roleid { get; set; }
        public int userid { get; set; }
        [Required]
        public AssignLinkToRoleType accesstype { get; set; }
        [Required]
        public int createdby { get; set; }
        [Required]
        public int updatedby { get; set; }
        [Required]
        public bool deletedflag { get; set; }

    }
    public enum AssignLinkToRoleType
    {
        View = 0, Add, Manage
    }
}
