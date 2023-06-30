using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.PMT.PMTExecution.Queries.GetParameterItem
{
    public class ParameterDto
    {
        public int hhid { get; set; }
        public int pmtconfigureid { get; set; }
        public string hhids { get; set; }
        public int locationid { get; set; }
        public int surveyId { get; set; }
    }
}
