using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Application.MasterQuestionsItem.Queries
{
    public class MasterQuestionDto:IMapFrom<MasterQuestion>
    {
        [Key]

        public int questionnaireid { get; set; }
        public string questionnairename { get; set; }
        public int moduleid { get; set; }
    }
}
