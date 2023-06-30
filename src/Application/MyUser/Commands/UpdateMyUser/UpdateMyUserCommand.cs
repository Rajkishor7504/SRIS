using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Text.RegularExpressions;

namespace SRIS.Application.MyUsers.Commands.UpdateMyUser
{
    public class UpdateMyUserCommand : IRequest<int>
    {
        public string action { get; set; }
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string userfullname { get; set; }
        public string usermobile { get; set; }
        public int roleid { get; set; }
        public int userroleid { get; set; }
        public string password { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public int? gender { get; set; }
    }

    public class UpdateMyUserCommandHandler : IRequestHandler<UpdateMyUserCommand,int>
    {
        private readonly IMyUserService _iMyUserService;

        public UpdateMyUserCommandHandler(IMyUserService iMyUserService)
        {
            _iMyUserService = iMyUserService;
        }

        public async Task<int> Handle(UpdateMyUserCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            Regex rgx1 = new Regex("[^A-Za-z0-9 ]");
            var entity = await _iMyUserService.GetMyUser(request.id);
            int retval = 0;
            if (entity == null)
            {
                throw new NotFoundException(nameof(MyUser), request.id);
            }
            try
            {
                entity.action = request.action;
                entity.username = request.username;
                entity.email = request.email;
                entity.userfullname = request.userfullname;
                entity.usermobile = request.usermobile;
                entity.roleid = request.roleid;
                entity.userroleid = request.userroleid;
                entity.startdate = request.startdate;
                entity.enddate = request.enddate;
                entity.gender = request.gender;
                bool hasSpecialChars = rgx.IsMatch(entity.userfullname);
                bool hasSpecialChars1 = rgx1.IsMatch(entity.username);
                if (hasSpecialChars == false && hasSpecialChars1 == false)
                {
                    retval = await _iMyUserService.UpdateMyUser(entity);
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

            return retval;
        }
    }
}
