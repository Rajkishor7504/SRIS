using System.ComponentModel.DataAnnotations;

namespace SRIS.Domain.Entities
{
    public class AccessLinkMaster
    {
        [Key]
      //  public int roleid { get; set; }
        public int linkaccessid { get; set; }
        [Required]
        public int plinkid { get; set; }
        [Required]
        public int userid { get; set; }
        [Required]
        public AccessLinkType accesstype { get; set; }        
        [Required]
        public int createdby { get; set; }
        [Required]
        public int updatedby { get; set; }
        [Required]
        public bool deletedflag { get; set; }
       // public int roleid { get; set; }

    }
    public enum AccessLinkType
    {
        View = 0, Add, Manage
    }
}
