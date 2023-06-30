/*
* File Name : PrimaryLinkMasterDto.cs
* class Name : PrimaryLinkMasterDto
* Created Date : 29th May 2021
* Created By : Spandana Ray
* Description : Primary Link DTO
*/

using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;

namespace SRIS.Application.PrimaryLinkMasters.Queries.GetPrimaryLinkMaster
{
    public class PrimaryLinkMasterDto : IMapFrom<PrimaryLinkMaster>
    {
        public string plinkname { get; set; }
        public int plinkid { get; set; }
        public int glinkid { get; set; }

        public string glinkname { get; set; }
        public string controllername { get; set; }
        public string actionname { get; set; }
        public bool deletedflag { get; set; }
        public string areaname { get; set; }
    }
}
