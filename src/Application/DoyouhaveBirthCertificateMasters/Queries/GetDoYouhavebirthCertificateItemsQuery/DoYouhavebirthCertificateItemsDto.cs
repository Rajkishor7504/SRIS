using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.DoyouhaveBirthCertificateMasters.Queries.GetDoYouhavebirthCertificateItemsQuery
{
    public class DoYouhavebirthCertificateItemsDto : IMapFrom<DoyouhaveBirthCertificate>
    {
        
        public int id { get; set; }
        public string doyouhavebirthcertificate { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }
    }
}
