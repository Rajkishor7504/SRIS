using SRIS.Domain.Entities.MasterEntities;
using System.ComponentModel.DataAnnotations;

namespace SRIS.Domain.Entities.Grievance
{
    public class GrievanceStatus : BaseEntity
    {
        [Key]
        public int statusid { get; set; }
        public int grievanceId { get; set; }
        public ResolutionStatus status { get; set; }
        public string remarks { get; set; }
        public string purpose { get; set; }
        public string grievancedocument { get; set; }
    }
}
