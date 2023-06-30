using SRIS.Application.EthnicityMasters.Commands.CreateEthnicityMasterList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.EthnicityMasters.Queries.GetEthnicityMaster
{
    public class EthnicityMasterVM
    {
        public IList<EthnicityMasterDto> Lists { get; set; }
        public CreateEthnicityMasterCommand command { get; set; }
        public int ethnicityid { get; set; }

        [DataMember]
        
        [Display(Name = "Ethnicity Name")]     
        public string ethnicityname { get; set; }       
        [Display(Name = "Description")]
        public string description { get; set; }
      
    }
}
