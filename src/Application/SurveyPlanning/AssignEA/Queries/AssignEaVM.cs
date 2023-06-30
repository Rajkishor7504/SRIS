using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Application.SurveyPlanning.AssignEA.Queries
{
    public class AssignEaVM
    {
        public AssignEaVM()
        {
            Lists = new List<AssignEADto>();
        }
        public string action { get; set; }

        public string actiontype { get; set; }
        public int planid { get; set; }

        [Required]
        [Display(Name = "EA Number")]
        public string eanumber { get; set; }
        public int createdby { get; set; }

        public int userid { get; set; }
        public int assigneaid { get; set; }
        public IList<AssignEADto> Lists { get; set; }

        public string levelname { get; set; }
        public int levelid { get; set; }
        public int supervisorlocationid { get; set; }
        public int ealocationid { get; set; }

    }
}
