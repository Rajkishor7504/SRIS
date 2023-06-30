using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.CopingStrategy.Queries.GetCopingInfoQuery
{
    public class CopingInfoDto
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int copingid { get; set; }
        public int createdby { get; set; }
        
        public int apptypeid { get; set; }
        public List<LivelihoodCoping> livehlihoodcoping { get; set; }
        public List<FoodCoping> foodcoping { get; set; }
    }
    public class LivelihoodCoping
    {
       public int lcopingdetailid { get; set; }
        public int lcopingid { get; set; }
        public int lresortingneedid { get; set; }
        public int strategyid { get; set; }
        public int lockstatus { get; set; }

        //for view purpose
        public string lcopingnamev { get; set; }
        public string lresortingneedv { get; set; }
        public int approvestatus { get; set; }
        public string RejectRemark { get; set; }
        public int updatestatus { get; set; }
        
        //end
    }
    public class FoodCoping
    {
        public int fcopingdetailid { get; set; }
        public int fcopingid { get; set; }
        public int fresortingneedid { get; set; }
        public int strategyid { get; set; }

        //for view purpose
        public string fcopingnamev { get; set; }
        public string fresortingneedv { get; set; }

        public int lockstatus { get; set; }
        //end
    }

    public class CopingStatusInfoDto
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int copingid { get; set; }
        public int createdby { get; set; }
        public string remark { get; set; }
        public int id { get; set; }
        public int parameterid { get; set; }
        public int apptypeid { get; set; }
       
    }
}
