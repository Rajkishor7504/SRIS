using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.UpdateHousehold.Queries
{
   public class UpdatehouseholdVM
    {
        public IList<UpdateHouseholdDto> Lists { get; set; }
        public string action { get; set; }
        public string householdno { get; set; }
        public int updatepriorityid { get; set; }
        public string hhheadname { get; set; }
        public DateTime updatedate { get; set; }
        public string updatecategoryid { get; set; }
        public string contactno { get; set; }
        public int updatesourceid { get; set; }
        public string updatesource { get; set; }
        public string updatedescription { get; set; }
        public int createdby { get; set; }
        public int status { get; set; }
        public string updatereason { get; set; }
        public int p_id { get; set; }
        public int requestid { get; set; }
        public string updatecatagoriesid { get; set; }
        public Array updcatagory { get; set; }
        public int grievanceregistrationid { get; set; }
        public int updcatagorydetailsid { get; set; }
        public string hhnumber { get; set; }
        public string remarks { get; set; }
        public int purposeid { get; set; }
        public string purposename { get; set; }
        public string complainno { get; set; }
        public int levelid { get; set; }
        public string levelname { get; set; }
        public int parentid { get; set; }
        public int leveldetailid { get; set; }
        public int hhid { get; set; }
        public int moduleid { get; set; }
        public int allapprovedstatus { get; set; }
        public int alllockstatus { get; set; }
        public string grivstatus { get; set; }
        public DateTime dateofcreate { get; set; }



    }
}
