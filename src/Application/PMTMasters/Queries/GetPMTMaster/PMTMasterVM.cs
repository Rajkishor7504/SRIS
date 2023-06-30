using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Application.PMTMasters.Queries.GetPMTMaster
{
    public class PMTMasterVM
    {
        public IList<PMTMasterDto> Lists { get; set; }

        public PMTMasterDto pMTMasterDto { get; set; }

        //public int pmtid { get; set; }

        //[Required]
        //[Display(Name = "Quantile")]
        //public int categoryid { get; set; }

        //[Required]
        //[Display(Name = "Topcutoff")]
        //[RegularExpression(@"^[0-9]*$", ErrorMessage = "Please enter numbers for topcutoff.")]
        //public int topcutoff { get; set; }

        //[Required]
        //[Display(Name = "Buttomcutoff")]
        //[RegularExpression(@"^[0-9]*$", ErrorMessage = "Please enter numbers for buttomcutoff.")]
        //public int buttomcutoff { get; set; }
        //public int id { get; set; }
        //public string quantile { get; set; }
        public int categoryid { get; set; }
        public string category { get; set; }

        public Decimal min_value { get; set; }
        public Decimal max_value { get; set; }
    }
}
