using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.AssetInfo.Queries.GetAssetInfoQuery
{
    public class AssetInfoDto
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int createdby { get; set; }
        public int apptypeid { get; set; }
        public int assetid { get; set; }
        public List<AssetInfoDetail> assetdetail { get; set; }
    }
    public class AssetInfoDetail
    {
        public int assetdetailid { get; set; }
        public int mediumid { get; set; }
        public int isavailable { get; set; }
        public int totalno { get; set; }
        public int item1age { get; set; }
        public int item2age { get; set; }

        //for view purpose
        public string mediumv { get; set; }
        public string isavailablev { get; set; }
        public int totalnov { get; set; }
        public int item1agev { get; set; }
        public int item2agev { get; set; }
        public int assetid { get; set; }
        //end 


        //Spot Checker  & enumerator
        //Truck/Lorry

        public string truckmediumv { get; set; }
        public string truckisavailablev { get; set; }
        public int trucktotalnov { get; set; }
        public int truckitem1agev { get; set; }
        public int truckitem2agev { get; set; }
        public int truckassetid { get; set; }

        public int truckassetdetailid_spt { get; set; }
        public string truckisavailablev_spt { get; set; }
        public int trucktotalnov_spt { get; set; }
        public int truckitem1agev_spt { get; set; }
        public int truckitem2agev_spt { get; set; }
        public int truckassetid_spt { get; set; }
        public int lockstatus { get; set; }
        public int approvestatus { get; set; }
        public string RejectRemark { get; set; }
        public int updatestatus { get; set; }
        
    }


    public class AssetStatusInfoDto
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int createdby { get; set; }
        public int apptypeid { get; set; }
        public int assetid { get; set; }
        public string remark { get; set; }
        public int id { get; set; }
        public int parameterid { get; set; }
    }
}
