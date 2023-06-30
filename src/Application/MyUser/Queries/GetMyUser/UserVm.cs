using System;
using System.Collections.Generic;

namespace SRIS.Application.MyUsers.Queries.GetMyUser
{
    public class MyUserVm
    {
        public MyUserVm()
        {
            Lists = new List<MyUserDto>();
        }
        public string action { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }        
        public string userfullname { get; set; }
        public string usermobile { get; set; }
        public IList<MyUserDto> Lists { get; set; }
        public int Id { get; set; }
        public string Secretkey { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public int gender { get; set; }
        public int userroleid { get; set; }
        public int roleid { get; set; }
        public string rolename { get; set; }
        public int spotchecker { get; set; }
        public string gendername { get; set; }
        public int createdby { get; set; }
     

    }
}
