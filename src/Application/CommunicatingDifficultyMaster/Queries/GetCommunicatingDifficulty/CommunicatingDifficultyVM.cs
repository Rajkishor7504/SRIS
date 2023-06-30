using SRIS.Application.CommunicatingDifficultyMaster.Commands.CreateCommunicatingDifficultyMasterItem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.CommunicatingDifficultyMaster.Queries.GetCommunicatingDifficulty
{
  public  class CommunicatingDifficultyVM
    {
        public IList<CommunicatingDifficultyDto> Lists { get; set; }
        public CreateCommunicatingDifficultyCommand command { get; set; }
        public int id { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }
        public string description { get; set; }
    }
}
