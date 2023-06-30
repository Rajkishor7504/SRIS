using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Userlogin_lgouttime.Queries.Userlogin_logouttimeQuery;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Userlogin_lgouttime.Command.Create_User_Login_logout_Time_Command
{
    public class CreateUser_Login_Logout_TimeCommand : IRequest<int>
    {
        public int id { get; set; }
        public int userid { get; set; }
        public string user_ipadress { get; set; }
        public DateTime login_time { get; set; }
        public DateTime logout_time { get; set; }
    }
    public class CreateUser_Login_Logout_TimeCommandHandler : IRequestHandler<CreateUser_Login_Logout_TimeCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;
        private readonly IUserloginlogouttimeServices _iUserLoginlogouttime;


        public CreateUser_Login_Logout_TimeCommandHandler(IApplicationDbContext context, IDateTime dateTime, IUserloginlogouttimeServices iUserLoginlogouttime)
        {
            _context = context;
            _dateTime = dateTime;
            _iUserLoginlogouttime = iUserLoginlogouttime;
        }

        public async Task<int> Handle(CreateUser_Login_Logout_TimeCommand request, CancellationToken cancellationToken)
        {
            var entity = new UserLogin_Logout_time();
            var entity1 = new Userlogin_logouttimeDto();
            int retval = 0;
            
            
            try
            {
                if (request.id == 0)
                {
                    entity.id = request.id;
                    entity.userid = request.userid;
                    entity.user_ipadress = request.user_ipadress;
                    entity.login_time = _dateTime.Now;
                    _context.m_user_login_logout_time.Add(entity);
                    await _context.SaveChangesAsync(cancellationToken);
                    retval = 1;

                }
                else
                {
                    entity1.id = request.id;
                    entity1.logout_time = DateTime.Now;
                    retval = await _iUserLoginlogouttime.Updateduser(entity1);
                    await _context.SaveChangesAsync(cancellationToken);
                    retval = 2;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return retval;
        }


    }
}
