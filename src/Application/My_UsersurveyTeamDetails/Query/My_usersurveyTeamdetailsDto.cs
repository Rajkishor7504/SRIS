using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Application.My_UsersurveyTeamDetails.Query
{
    public class My_usersurveyTeamdetailsDto
    {[Key]
        public int id { get; set; }
        public string username { get; set; }
        public string userfullname { get; set; }

        public int userroleid { get; set; }
        public string action { get; set; }
        //public int teamdetailid { get; set; }
        //public int teamid { get; set; }
        //public int userid { get; set; }
        //public int usettypeid { get; set; }




    }
}
