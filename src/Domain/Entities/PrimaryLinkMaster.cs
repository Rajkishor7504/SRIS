using System.ComponentModel.DataAnnotations;

namespace SRIS.Domain.Entities
{
    public class PrimaryLinkMaster
    {
        [Key]
        public int plinkid { get; set; }
        [Required]
        public int glinkid { get; set; }
        [Required]
        public string plinkname { get; set; }
        public string controllername { get; set; }
        public string actionname { get; set; }
        public string areaname { get; set; }
        [Required]
        public int createdby { get; set; }
        [Required]
        public int updatedby { get; set; }
        [Required]
        public bool deletedflag { get; set; }
    }
}
