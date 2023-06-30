using SRIS.Application.UserRoleMasters.Queries.GetUserRoleMaster;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.SurveyPlanning.EnumeratorProfile.Queries
{
   public class EnumeratorProfileVM
    {
        public EnumeratorProfileVM()
        {
            Lists = new List<EnumeratorProfileDto>();
        }
        public int id { get; set; }
        public string action { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string userfullname { get; set; }
        public string email { get; set; }
        public string usermobile { get; set; }
        public int userroleid { get; set; }
        public string Secretkey { get; set; }
        public DateTime enumeratorstartdate { get; set; }
        public DateTime enumeratorenddate { get; set; }
        public int? gender { get; set; }
        public int? assignedstatus { get; set; }
        public int spotchecker { get; set; }
        public int createdby { get; set; }
        public IList<EnumeratorProfileDto> Lists { get; set; }
        public int usertype { get; set; }
        public string pwd { get; set; }
       



    }
}
