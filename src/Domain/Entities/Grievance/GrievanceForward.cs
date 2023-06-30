using SRIS.Domain.Entities.MasterEntities;
using System.ComponentModel.DataAnnotations;

namespace SRIS.Domain.Entities.Grievance
{
    public class GrievanceForward : BaseEntity
    {
        [Key]
        public int forwardedId { get; set; }
        public int grievanceId { get; set; }
        public int forwardedBy_userId { get; set; }
        public int forwardedBy_committeeId { get; set; }
        public int forwardedTo_committeeId { get; set; }
        public ForwardStatus status { get; set; }
        public string remarks { get; set; }
    }
}
