using SRIS.Application.RelationMasters.Commands.CreateRelationMasterList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.RelationMasters.Queries.GetRelationMaster
{
    public class RelationMasterVM
    {
        public IList<RelationMasterDto> Lists { get; set; }
        public CreateRelationMasterCommand command { get; set; }
        public int id { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Relation Name")]
        //[RegularExpression(@"[A-Za-z0-9 ]*", ErrorMessage = "Please enter valid relation name.")]
        public string relationname { get; set; }

        
        public string description { get; set; }

    }
    
}
