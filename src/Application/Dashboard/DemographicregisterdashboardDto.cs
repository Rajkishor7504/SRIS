using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Application.Dashboard
{
    public class DemographicregisterdashboardDto
    {[Key]
    public int memberid { get; set; }
        public int hhid { get; set; }
        public int sex { get; set; }
        public DateTime createdon { get; set; }

    }
}
