using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.EcologyMaster.Queries.GetEcologyTypeMasterQuery
{
    public class EcologyMasterVM
    {
        public IList<EcologyMasterDto> Lists { get; set; }
        public int type_id { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Ecology Type")]
        public string type_name { get; set; }
    }
}
