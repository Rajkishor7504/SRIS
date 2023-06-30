using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.UMUserLocationMasterItem.Queries.GetUMUserLocationMasterItem
{
    public class UMUserLocationDto:IMapFrom<UMUserLocation>
    {
        public int userlocid { get; set; }
        public int roleid { get; set; }
        public int userid { get; set; }
        public int taglocationid { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public string action { get; set; }
        public int p_id { get; set; }
        public int levelid { get; set; }
        public int? createdby { get; set; }
        public string levelname { get; set; }
        public int parentid { get; set; }
        public int leveldetailid { get; set; }
        public string rolename { get; set; }
        public string userfullname { get; set; }
        public string locname { get; set; }
        public string loctype { get; set; }
        public string deletevalue { get; set; }
        public string region { get; set; }
        public string district { get; set; }
        public int usrlocid { get; set; }
        public int usrlocid1 { get; set; }
        public List<UMUserLocationDto> Lists { get; set; }
    }
}
