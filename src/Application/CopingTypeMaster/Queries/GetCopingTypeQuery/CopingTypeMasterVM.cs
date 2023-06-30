using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.CopingTypeMaster.Queries.GetCopingTypeQuery
{
    public class CopingTypeMasterVM
    {
        public IList<CopingTypeMasterDto> Lists { get; set; }
        public int copingtypeid { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Coping Type")]
        public string copingtypename { get; set; }
        public string description { get; set; }
    }
}
