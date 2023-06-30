using SRIS.Domain.Entities.MasterEntities;
using System;
using System.ComponentModel.DataAnnotations;
namespace SRIS.Domain.Entities
{
    public class GrievanceAssignSurveyManager : BaseEntity
    {
        [Key]
        public int pkid { get; set; }
        public int grievanceid { get; set; }
        public int planid { get; set; }
        public string surveymanager { get; set; }
        public string surveyname { get; set; }
        public int surveymanagerid { get; set; }
        public int status { get; set; }
        public string remarks { get; set; }
        public int remarksgivenby { get; set; }
        public DateTime remarksgivendate { get; set; }
    }
}
