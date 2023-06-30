using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.ClusterMaster.Queries.GetClusterMasterQueries
{
   public class ClusterMasterDto
    {
        //created by Deepak Kumar Sahu 
        //public ClusterMasterDto()
        //{
        //}
        public int eano { get; set; }   //Changes by Deepak Kumar Sahu(16-09-2022)
        public string levelname { get; set; }
        public int levelid { get; set; }
        public int leveldetailid { get; set; }
        public int parentid { get; set; }
        public string action { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
        public int clusterno { get; set; }
        public int createdby { get; set; }
        public int id { get; set; }
        public string createddate { get; set; }
        public string lganame { get; set; }
        public string districtname { get; set; }
        public string wardname { get; set; }
        public string settlementname { get; set; }

        //add excel data(start)
        public List<ClusterMasterDto> Lists { get; set; }
        public string exeano { get; set; }
        public string exclusterno { get; set; }
        public string exregionno { get; set; }
        public string exdistrictno { get; set; }
        public string exwardno { get; set; }
        public string exsettlementno { get; set; }
        //add excel data(end)
    }
}
