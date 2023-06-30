using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.PMT.PMTParameterMasterItem.Queries.GetPMTParameterMasterItem
{
    public class PMTParameterVM
    {
        public PMTParameterVM()
        {
            Lists = new List<PMTParameterDto>(); 
        }
        public IList<PMTParameterDto> Lists { get; set; }
        //public PMTParameterDto pmtparameterdto { get; set; }
        public int parameterid { get; set; }
        public int planid { get; set; }
        public int moduleid { get; set; }
        public int questionnaireid { get; set; }
        public int pmtmasterid { get; set; }
        public int yesvalue { get; set; }
        public int novalue { get; set; }
        public string modulename { get; set; }
        public string surveyname { get; set; }
        public string questionnairename { get; set; }
        public string parametername { get; set; }
        public int levelid { get; set; }
        public string levelname { get; set; }

    }
}
