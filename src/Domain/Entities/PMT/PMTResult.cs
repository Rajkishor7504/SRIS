using SRIS.Domain.Entities.MasterEntities;
using System.ComponentModel.DataAnnotations;

namespace SRIS.Domain.Entities.PMT
{
    public class PMTResult : BaseEntity
    {
        [Key]
        public int resultid { get; set; }
        public int hhid { get; set; }
        public int pmtconfigureid { get; set; }
        public double pmtscore { get; set; }
        public int hhstatus { get; set; }
        public string remarks { get; set; }
    }
    public class PMTResultParameter : BaseEntity
    {
        [Key]
        public int resultid { get; set; }
        public int moduleid { get; set; }
        public int parameterid { get; set; }
        public int questionnaireid { get; set; }
        public int pmtmasterid { get; set; }
        public int? yesvalue { get; set; }
        public int? novalue { get; set; }
        public double coefficient { get; set; }
        public double constant { get; set; }
        public double hhvalue { get; set; }
        public double formulaconstant { get; set; }
    }
    public class PMTScore : BaseEntity
    {
        [Key]
        public int scoreid { get; set; }
        public int resultid { get; set; }
        public int hhid { get; set; }
        public string hhcategory { get; set; }
    }

}
