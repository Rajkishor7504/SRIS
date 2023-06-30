using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.SurveyPlanning.EnumerationArea.Command
{
   public class EanoAreaDto
    {
        public int regionid { get; set; }
        public int districtid { get; set; }
        public int settlementid { get; set; }
    }
    public class EanoAreaindoDto
    {
        public int enumdetlid { get; set; }
        public int eaid { get; set; }
        public int createdby { get; set; }       
        public int surveyplanid { get; set; }
        public string eano { get; set; }
        public string action { get; set; }
        public int clusterno { get; set; }
        public int regionid { get; set; }
        public int distid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
        public List<EanoAreaDto> locationdata { get; set; }
    }
}
