using System;
using System.ComponentModel.DataAnnotations;

namespace SRIS.Domain.Entities
{
    public class BeneficiaryDetail
    {
        [Key]
        public int benificiaryid { get; set; }
        public int programdtlsid { get; set; }
        public string benificiaryname { get; set; }
        public string householdno { get; set; }
        public string idnumber { get; set; }
        public string location { get; set; }
        public string householdhead { get; set; }
        public string gender { get; set; }
        public string enrollmentstatus { get; set; }
        public DateTime regdate { get; set; }
        public int createdby { get; set; }
        public DateTime createdon { get; set; }
        public bool deletedflag { get; set; }
        public int hhid { get; set; }
    }
}
