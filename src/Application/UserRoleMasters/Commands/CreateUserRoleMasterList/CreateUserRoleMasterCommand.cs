using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.UserRoleMasters.Commands.CreateUserRoleMasterList
{   
    public class  CreateUserRolekMasterCommand : IRequest<int>
    {
        public int roleid { get; set; }
        public string rolename { get; set; }
        public string description { get; set; }
    }
    public class CreateUserRolekMasterCommandHandler : IRequestHandler<CreateUserRolekMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateUserRolekMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateUserRolekMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx1 = new Regex("[^A-Za-z0-9 ]");
            var entity = new UserRoleMaster();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_um_UserRole.Where(x => x.rolename == request.rolename).Count();
                if (count == 0)
                {
                    if (request.roleid == 0)
                    {
                        entity.rolename = request.rolename;
                        entity.description = request.description;
                       //entity.MenuOrder = _context.m_adm_globallink.OrderByDescending(g => g.MenuOrder).FirstOrDefault().MenuOrder + 1;
                        entity.createdby = 1;
                        entity.updatedby = 1;
                        entity.deletedflag = false;
                        entity.roleid = request.roleid;

                        bool hasSpecialChars = rgx1.IsMatch(entity.rolename);
                        if (entity.description != "")
                        {
                            bool hasSpecialChars1 = rgx1.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_um_UserRole.Add(entity);

                                await _context.SaveChangesAsync(cancellationToken);
                                retval = 1;
                            }
                            else
                            {
                                retval = 403;
                            }
                        }

                        else if (hasSpecialChars == false)
                        {

                            _context.m_um_UserRole.Add(entity);

                            await _context.SaveChangesAsync(cancellationToken);
                            retval = 1;
                        }
                        else
                        {
                            retval = 403;


                        }
                    }

                }
                else
                {
                    retval = 3;
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