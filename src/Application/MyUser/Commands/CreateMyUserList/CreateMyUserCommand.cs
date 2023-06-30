using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.MyUsers.Queries.GetMyUser;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.MyUsers.Commands.CreateMyUser
{
    public class CreateMyUserCommand : IRequest<int>
    {
        public string action { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string userfullname { get; set; }
        public string usermobile { get; set; }
        public int roleid { get; set; }
        public string rolename { get; set; }
        public int userroleid { get; set; }
        public string Secretkey { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public int gender { get; set; }
        public int Id { get; set; }
        public IList<MyUserDto> Lists { get; set; }
        public int spotchecker { get; set; }
        public int createdby { get; set; }

    }

    public class CreateMyUserCommandHandler : IRequestHandler<CreateMyUserCommand, int>
    {
        private readonly IMyUserService _iMyUserService;

        public CreateMyUserCommandHandler(IMyUserService iMyUserService)
        {
            _iMyUserService = iMyUserService;
        }

        public async Task<int> Handle(CreateMyUserCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            Regex rgx1 = new Regex("[^A-Za-z0-9 ]");
            int retval = 0;
            var entity = new MyUserDto();
            try
            {
                entity.action = request.action;
                entity.username = request.username;
                entity.email = request.email;
                entity.password = request.password;
                entity.userfullname = request.userfullname;
                entity.usermobile = request.usermobile;
                entity.roleid = request.roleid;
                entity.Secretkey = request.Secretkey;
                entity.startdate = request.startdate;
                entity.enddate = request.enddate;
                entity.gender = request.gender;
                entity.userroleid = request.userroleid;
                bool hasSpecialChars = rgx.IsMatch(entity.userfullname);
                bool hasSpecialChars1 = rgx1.IsMatch(entity.username);
                if (hasSpecialChars == false && hasSpecialChars1 == false)
                {
                    retval = await _iMyUserService.AddMyUser(entity);
                }
                else
                {
                    retval = 403;


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //Need to Check return id or unit
            return retval;
          
        }
    }
}
