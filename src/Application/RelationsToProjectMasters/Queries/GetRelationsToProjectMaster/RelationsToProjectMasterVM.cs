using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.RelationsToProjectMasters.Queries.GetRelationsToProjectMaster
{
    public class RelationsToProjectMasterVM
    {
        public IList<RelationsToProjectMasterDto> Lists { get; set; }
        //  public CreateshocksSeverityMasterCommand command { get; set; }
        public int relationid { get; set; }
        public string relationname { get; set; }
        public string description { get; set; }
    }
}
