using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.SecondIncomeSourceMaster.Queries.GetSecondIncomeSourceMasterQuery
{
    public class SecondIncomeSourceVM
    {
        public IList<SecondIncomeSourceDto> Lists { get; set; }
        public int secondincomesourceid { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Second Income Source")]
        public string secondincomesourcename { get; set; }
        public string description { get; set; }
    }
}
