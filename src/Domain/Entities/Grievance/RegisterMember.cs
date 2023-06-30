using SRIS.Domain.Entities.MasterEntities;
using System.ComponentModel.DataAnnotations;

namespace SRIS.Domain.Entities.Grievance
{
    public class RegisterMember : BaseEntity
    {
        [Key]
        public int memberid { get; set; }
        public int userid { get; set; }
        public int comitteid { get; set; }
        public string commiteemembername { get; set; }
        public string fathername { get; set; }
        public int memberpositionid { get; set; }
        public string contactnumber { get; set; }
        public string email { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
    }
}
