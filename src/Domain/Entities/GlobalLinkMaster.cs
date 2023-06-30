using System.ComponentModel.DataAnnotations;

namespace SRIS.Domain.Entities
{
    public class GlobalLinkMaster
    {
        [Key]
        public int glinkid { get; set; }
        [Required]
        public string glinkname { get; set; }        
        [Required]
        public int createdby { get; set; }
        [Required]
        public int updatedby { get; set; }
        [Required]
        public bool deletedflag { get; set; }
        public int MenuOrder { get; set; }
    }
}
