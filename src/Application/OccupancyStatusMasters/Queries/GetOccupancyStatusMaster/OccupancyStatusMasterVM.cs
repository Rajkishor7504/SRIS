using SRIS.Application.OccupancyStatusMasters.Commands.CreateOccupancyStatusMasterList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.OccupancyStatusMasters.Queries.GetOccupancyStatusMaster
{
   public class OccupancyStatusMasterVM
    {
        public IList<OccupancyStatusMasterDto> Lists { get; set; }
        public CreateOccupancyStatusMasterCommand Command { get; set; }
        public int id { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Occupancy Status Name")]
        //[RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid OccupancyStatus Name.")]
        public string occupancyStatusName { get; set; }

        
        [Display(Name = "Description")]
        //[RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid description")]
        public string description { get; set; }
    }
}
