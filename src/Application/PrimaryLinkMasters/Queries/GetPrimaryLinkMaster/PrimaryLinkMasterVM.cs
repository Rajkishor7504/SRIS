/*
* File Name : PrimaryLinkMasterVM.cs
* class Name : PrimaryLinkMasterVM
* Created Date : 29th May 2021
* Created By : Spandana Ray
* Description : Primary Link VM
*/

using System.Collections.Generic;

namespace SRIS.Application.PrimaryLinkMasters.Queries.GetPrimaryLinkMaster
{
    public class PrimaryLinkMasterVM
    {
        public IList<PrimaryLinkMasterDto> Lists { get; set; }
        public int plinkid { get; set; }
        public string plinkname { get; set; }
        public int glinkid { get; set; }
        public string controllername { get; set; }
        public string actionname { get; set; }
        public string areaname { get; set; }
    }
}
