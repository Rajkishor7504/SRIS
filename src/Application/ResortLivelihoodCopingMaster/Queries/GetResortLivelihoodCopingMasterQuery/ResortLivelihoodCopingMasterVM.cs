using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.ResortLivelihoodCopingMaster.Queries.GetResortLivelihoodCopingMasterQuery
{
    public class ResortLivelihoodCopingMasterVM
    {
        public IList<ResortLivelihoodCopingMasterDto> Lists { get; set; }
        public int resortlivelyhoodcopingid { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Resorting Livelihood Coping Startegies")]
        public string resortlivelyhoodcoping { get; set; }
        public string description { get; set; }
    }
}
