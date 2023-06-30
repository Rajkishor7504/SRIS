using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SchoolTypeMaster.Commands.CreateSchoolTypeMasterItem
{
   public class CreateSchoolTypeCommand : IRequest<int>
    {
        public int schooltypeid { get; set; }
        public string typeofschool { get; set; }
        public string description { get; set; }
    }
    public class CreateSchoolTypeCommandHandler : IRequestHandler<CreateSchoolTypeCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _datetime;

        public CreateSchoolTypeCommandHandler(IApplicationDbContext context, IDateTime datetime)
        {
            _context = context;
            _datetime = datetime;
        }

        public async Task<int> Handle(CreateSchoolTypeCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new TypeOfSchoolEntities();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_Schooltype.Where(x => x.typeofschool == request.typeofschool && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.schooltypeid == 0)
                    {
                        int id = _context.m_master_Schooltype.ToListAsync().Result.LastOrDefault().schooltypeid;
                        entity.typeofschool = request.typeofschool;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.createdon = _datetime.Now;
                        entity.deletedflag = false;
                        entity.schooltypeid = id + 1;
                        bool hasSpecialChars = rgx.IsMatch(entity.typeofschool);
                        if (entity.description != "")
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_Schooltype.Add(entity);

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

                            _context.m_master_Schooltype.Add(entity);

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
