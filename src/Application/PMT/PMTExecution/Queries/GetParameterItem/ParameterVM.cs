using System.Collections.Generic;

namespace SRIS.Application.PMT.PMTExecution.Queries.GetParameterItem
{
    public class ParameterVM
    {
        public ParameterVM()
        {
            Lists = new List<ParameterDto>();
        }
        public IList<ParameterDto> Lists { get; set; }
        public string hhids { get; set; }
        public int hhid { get; set; }
        public int pmtconfigureid { get; set; }
        public int locationid { get; set; }
        public int surveyId { get; set; }
    }
}
