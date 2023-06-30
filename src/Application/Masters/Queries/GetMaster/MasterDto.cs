using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using System;

namespace SRIS.Application.Masters.Queries.GetMaster
{
    public class MasterDto : IMapFrom<Master>
{
        public MasterDto()
        {
        }

        public int Id { get; set; }

       public string Name { get; set; }

       public string description { get; set; }

        //added by jyotishikha for demography master

        public string levelname { get; set; }
        public int levelid { get; set; }
        public int leveldetailid { get; set; }
        public int parentid { get; set; }
        public int createdby { get; set; }
        public bool deletedflag { get; set; }
        public string code { get; set; }
        public string action { get; set; }
        public int userid { get; set; }
        public int planid { get; set; }
        public string surveyname { get; set; }
        public int surveyplanid { get; set; }
        public DateTime surveystartdate { get; set; }
        public DateTime surveyenddate { get; set; }
        public int statusid { get; set; }
        public string status { get; set; }
        public DateTime surveyextendeddate { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public string extendeddate { get; set; }
        public int clusterno { get; set; }
    }
   
}
