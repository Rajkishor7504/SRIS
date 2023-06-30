using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SRIS.Application.MyUsers.Queries.GetMyUser
{
    public class MyUserDto : IMapFrom<MyUser>
    {
        public MyUserDto()
        {
        }
        public string action { get; set; }
        public int Id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string userfullname { get; set; }
        public string usermobile { get; set; }
        public int userroleid { get; set; }
        public int deleted { get; set; }
        public string Secretkey { get; set; }
        public string? startdate { get; set; }
        public string? enddate { get; set; }
        public int? gender { get; set; }
        public string gendername { get; set; }
        public int? assignedstatus { get; set; }
        public bool candelete { get; set; }
        public int spotchecker { get; set; }
        public int createdby { get; set; }
        public string spotcheckerstatus { get; set; }
        public List<MyUserDto> Lists { get; set; }
        public int roleid { get; set; }
        public string rolename { get; set; }
        public DateTime enumeratorstartdate { get; set; }
        public DateTime enumeratorenddate { get; set; }

    }
}
