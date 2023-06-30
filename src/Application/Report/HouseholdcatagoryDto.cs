using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Application.Report
{
    public class HouseholdcatagoryDto
    {[Key]
        public int hhid { get; set; }
        public int lga { get; set; }
        public string hhcategory { get; set; }
    }
}
