using SRIS.Application.WalkingDifficultyMaster.Commands.CreateWalkingDifficultyMasterItem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.WalkingDifficultyMaster.Queries.GetWalkingDifficulty
{
 public   class WalkingDifficultyVM
    {
        public IList<WalkingDifficultyDto> Lists { get; set; }
        public CreateWalkingDifficultyCommand command { get; set; }
        public int id { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }
        public string description { get; set; }
    }
}
