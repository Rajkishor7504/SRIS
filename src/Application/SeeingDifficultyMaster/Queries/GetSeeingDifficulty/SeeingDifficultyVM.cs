using SRIS.Application.SeeingDifficultyMaster.Commands.CreateSeeingDifficultyMasterItem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.SeeingDifficultyMaster.Queries.GetSeeingDifficulty
{
    public class SeeingDifficultyVM
    {
        public IList<SeeingDifficultyDto> Lists { get; set; }
        public CreateSeeingDifficultyCommand command { get; set; }
        public int id { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Name")]
        //[RegularExpression(@"[A-Za-z0-9 ]*", ErrorMessage = "Please enter Name.")]
        public string name { get; set; }
        public string description { get; set; }
    }
}
