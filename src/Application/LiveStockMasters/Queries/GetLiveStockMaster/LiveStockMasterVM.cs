using SRIS.Application.LiveStockMasters.Commands.CreateLiveStockMasterList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.LiveStockMasters.Queries.GetLiveStockMaster
{
    public class LiveStockMasterVM
    {
        public IList<LiveStockMasterDto> Lists { get; set; }
        public CreateLiveStockMasterCommand command { get; set; }
        public int livestockid { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Livestock Name")]
       // [RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid LiveStock Name")]
        public string livestockname { get; set; }

        //[DataMember]
        [Display(Name = "Description")]
       // [RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Description")]
        public string description { get; set; }
    }
}
