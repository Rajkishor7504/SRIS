using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.LastLevelGradeMaster.Queries.GetLastLevelGradeMasterQuery
{
    public class LastLevelGradeMasterQueryVM
    {
        public IList<LastLevelGradeMasterDto> Lists { get; set; }
        public int lastlevelid { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Last Level Grade")]
        public string lastlevelname { get; set; }
    }
}
