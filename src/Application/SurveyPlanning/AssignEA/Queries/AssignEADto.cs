using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Application.SurveyPlanning.AssignEA.Queries
{
    public class AssignEADto
    {
        public string action { get; set; }
        public int planid { get; set; }
        public string eanumber { get; set; }
        public int createdby { get; set; }
        public int userid { get; set; }
        public string surveyname { get; set; }
        public string username { get; set; }
        public int assigneaid { get; set; }

        public string levelname { get; set; }
        public int levelid { get; set; }

        public int regionid { get; set; }
        public int distid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }

        public string region { get; set; }
        public string dist { get; set; }
        public string ward { get; set; }
        public string settlement { get; set; }
        public int ealocationid { get; set; }
        public int supervisorlocationid { get; set; }
        public string enumerator { get; set; }
        public int parentid { get; set; }
        public List<AssignEADto> Lists { get; set; }
    }
}
