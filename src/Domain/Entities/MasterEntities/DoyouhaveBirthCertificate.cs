using System.ComponentModel.DataAnnotations;

using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
    public class DoyouhaveBirthCertificate : BaseEntity
    {
        [Key]
        public int id { get; set; }
        public string doyouhavebirthcertificate { get; set; }
        public string description { get; set; }
    }
}
