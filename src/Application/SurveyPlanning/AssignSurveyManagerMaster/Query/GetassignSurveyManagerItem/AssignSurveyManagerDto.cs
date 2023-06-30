using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.SurveyPlanning;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Application.SurveyPlanning.AssignSurveyManagerMaster.Query.GetassignSurveyManagerItem
{
    public class AssignSurveyManagerDto:IMapFrom<AssignSurveyManager>
    {[Key]
        public int assignmanagerid { get; set; }
        public int surveyplanid { get; set; }
        public int userid { get; set; }
        public string action { get; set; }
        public int createdby { get; set; }
        public string surveyname { get; set; }
        public string userfullname { get; set; }
        public List<AssignSurveyManagerDto> Lists { get; set; }
    }
}
