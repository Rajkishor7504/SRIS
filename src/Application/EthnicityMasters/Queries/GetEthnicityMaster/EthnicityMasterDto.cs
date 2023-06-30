using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.EthnicityMasters.Queries.GetEthnicityMaster
{
   public class EthnicityMasterDto : IMapFrom<EthnicityMaster>
    {
        public EthnicityMasterDto()
        {
        }      
        public string description { get; set; }
        public string ethnicityname { get; set; }
        public int ethnicityid { get; set; }
        public bool deletedflag { get; set; }
    }
}
