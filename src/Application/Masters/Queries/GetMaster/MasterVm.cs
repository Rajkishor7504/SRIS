using SRIS.Application.Masters.Commands.CreateMasterList;
using System;
using System.Collections.Generic;

namespace SRIS.Application.Masters.Queries.GetMaster
{
    public class MasterVm
    {
        public IList<MasterDto> Lists { get; set; }
        public IList<MasterDto> DistLists { get; set; }
        public IList<MasterDto> LGALists { get; set; }
        public IList<MasterDto> WardLists { get; set; }
        public CreateDemographyMasterCommand command { get; set; }
        public MasterDto masterDto { get; set; }
        public string status { get; set; }
        public string action { get; set; }
        public string levelname { get; set; }
        public int levelid { get; set; }
        public int leveldetailid { get; set; }
        public int parentid { get; set; }
        public string description { get; set; }
        public int createdby { get; set; }
        public string code { get; set; }
        public int ParentLGA { get; set; }
        public int ParentDist { get; set; }
        public int ParentWard { get; set; }
        public int ParentSettlement{ get; set; }
        public int planid { get; set; }
        public string surveyname { get; set; }
        public DateTime surveystartdate { get; set; }
        public DateTime surveyenddate { get; set; }
        public int statusid { get; set; }
        public DateTime surveyextendeddate { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public string extendeddate { get; set; }

        public int clusterno { get; set; }
        //public string userid { get; set; }

        //public int surveyplanid { get; set; }


    }
}
