/*
* File Name : RegisterMemberDto.cs
* class Name : RegisterMemberDto
* Created Date : 13th Aug 2021
* Created By : Spandana Ray
* Description : command class to register the grievance member
*/
using SRIS.Application.Common.Mappings;
using System;

namespace SRIS.Application.Grievances.Queries.GetRegisterMember
{
    public class RegisterMemberDto : IMapFrom<SRIS.Domain.Entities.Grievance.RegisterMember>
    {
        public int memberid { get; set; }
        public int userid { get; set; }
        public int comitteid { get; set; }
        public string commiteemembername { get; set; }
        public string fathername { get; set; }
        public int memberpositionid { get; set; }
        public string contactnumber { get; set; }
        public string email { get; set; }
        public int createdby { get; set; }
        public DateTime createdon { get; set; }
        public string commiteename { get; set; }
        public string memberposition { get; set; }
        public string rolename { get; set; }
        //public string memberposition {
        //    get
        //    {
        //        if (memberpositionid == 1)
        //            return "CGC";
        //        else if (memberpositionid == 2)
        //            return "DGC";
        //        else if (memberpositionid == 3)
        //            return "RGC";
        //        else if (memberpositionid == 4)
        //            return "NSPS";
        //        else
        //            return "NA";
        //    } 
        //}
        public int regionid { get; set; }
        public int districtid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
        public string password { get; set; }
        public string Secretkey { get; set; }
        public string region { get; set; }
        public string dist { get; set; }
        public string ward { get; set; }
        public string settlement { get; set; }
    }
}
