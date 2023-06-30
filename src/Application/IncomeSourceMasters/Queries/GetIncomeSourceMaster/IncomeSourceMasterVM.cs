﻿using SRIS.Application.IncomeSourceMasters.Commands.CreateIncomeSourceMasterList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.IncomeSourceMasters.Queries.GetIncomeSourceMaster
{
    public class IncomeSourceMasterVM
    {
        public IList<IncomeSourceMasterDto> Lists { get; set; }
        public CreateIncomeSourceMasterCommand command { get; set; }
        public int incomesourceid { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Income Source Name")]
       // [RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Income Source Name")]
        public string incomesourcename { get; set; }

        //[DataMember]
        [Display(Name = "Description")]
       // [RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Description")]
        public string description { get; set; }
    }
}
