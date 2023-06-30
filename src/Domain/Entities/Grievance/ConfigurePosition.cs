using SRIS.Domain.Entities.MasterEntities;
using System.ComponentModel.DataAnnotations;

namespace SRIS.Domain.Entities.Grievance
{
    public class ConfigurePosition : BaseEntity
    {
        [Key]
        public int positionid { get; set; }
        public int committeeid { get; set; }
        public string positionname { get; set; }
        public string description { get; set; }
    }
}
