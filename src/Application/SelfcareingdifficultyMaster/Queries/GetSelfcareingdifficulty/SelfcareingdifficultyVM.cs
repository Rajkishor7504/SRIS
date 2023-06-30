using SRIS.Application.SelfcareingdifficultyMaster.Command.CreateSelfcareingdifficultyMasterItem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.SelfcareingdifficultyMaster.Queries.GetSelfcareingdifficulty
{
    public class SelfcareingdifficultyVM
    {
        public IList<SelfcareingdifficultyDto> Lists { get; set; }
        public CreateSelfcareingdifficultyCommand command { get; set; }
        public int id { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Name")]
        //[RegularExpression(@"[A-Za-z0-9 ]*", ErrorMessage = "Please enter Name.")]
        public string name { get; set; }
        public string description { get; set; }
    }
}
