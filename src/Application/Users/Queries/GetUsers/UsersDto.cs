using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Users.Queries.GetUsers
{
   public class UsersDto : IMapFrom<User>
    {
        public UsersDto()
        {
        }
        public int id { get; set; }
        public string username { get; set; }

    }

}
