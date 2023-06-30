using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Application.AllMaster.EthnicityMaster.Queries.GetEthnicityListMaster
{
    
    public class EthnicityMasterDto
    {
        public int id { get; set; }

        [Required]
        [MaxLength(30)]
        public string name { get; set; }
    }
    public class EthnicityMasterVM
    {
        public IList<EthnicityMasterDto> Lists { get; set; }
    }
}
