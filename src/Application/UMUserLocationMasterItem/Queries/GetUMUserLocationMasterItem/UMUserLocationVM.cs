using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.UMUserLocationMasterItem.Queries.GetUMUserLocationMasterItem
{
    public class UMUserLocationVM
    {
        public UMUserLocationVM()
        {
            Lists = new List<UMUserLocationDto>();
        }
        public IList<UMUserLocationDto> Lists { get; set; }
        public int userlocid { get; set; }
        public int roleid { get; set; }
        public int userid { get; set; }
        public int taglocationid { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
        public int p_id { get; set; }
        public int? createdby { get; set; }
        public int levelid { get; set; }
        public string levelname { get; set; }
        public int parentid { get; set; }
        public int leveldetailid { get; set; }
        public string rolename { get; set; }
        public string userfullname { get; set; }
        public string locname { get; set; }
        public string loctype { get; set; }
        public string region { get; set; }
        public string district { get; set; }
    }
}
