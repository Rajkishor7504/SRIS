using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.DoyouhaveBirthCertificateMasters.Queries.GetDoYouhavebirthCertificateItemsQuery
{
    public class DoYouhavebirthCertificateItemsVM
    {
        public IList<DoYouhavebirthCertificateItemsDto> Lists { get; set; }
        public int id { get; set; }
        public string doyouhavebirthcertificate { get; set; }
        public string description { get; set; }
    }
}
