using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.ReadWriteAnyLanguageMaster.Queries.GetReadWriteAnyLanguageMasterQuery
{
    public class ReadWriteAnyLanguageMasterVM
    {
        public IList<ReadWriteAnyLanguageMasterDto> Lists { get; set; }
        public int readwriteid { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Can Read Or Write")]
        public string typeofreadwrite { get; set; }
        public string description { get; set; }
    }
}
