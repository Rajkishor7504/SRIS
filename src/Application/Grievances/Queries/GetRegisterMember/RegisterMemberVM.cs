/*
* File Name : RegisterMemberVM.cs
* class Name : RegisterMemberVM
* Created Date : 13th Aug 2021
* Created By : Spandana Ray
* Description : command class to register the grievance member
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Grievances.Queries.GetRegisterMember
{
    public class RegisterMemberVM
    {
        public int memberid { get; set; }
        public int comitteid { get; set; }
        public string commiteemembername { get; set; }
        public string fathername { get; set; }
        public int memberpositionid { get; set; }
        public string contactnumber { get; set; }
        public string email { get; set; }
        public int createdby { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
        public IList<RegisterMemberDto> Lists { get; set; }
        public string password { get; set; }
        public string Secretkey { get; set; }
        public string  rolename { get; set; }
    }
}
