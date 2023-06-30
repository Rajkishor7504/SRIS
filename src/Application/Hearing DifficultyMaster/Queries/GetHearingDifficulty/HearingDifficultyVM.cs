using SRIS.Application.Hearing_DifficultyMaster.Commands.CreateHearingDifficultyMasterItem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.Hearing_DifficultyMaster.Queries.GetHearingDifficulty
{
   public class HearingDifficultyVM
    {
        public IList<HearingDifficultyDto> Lists { get; set; }
        public CreateHearingDifficultyCommand command { get; set; }
        public int id { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }
        public string description { get; set; }
    }
}
