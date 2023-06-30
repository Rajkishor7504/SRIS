using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SchoolTypeMaster.Commands.UpdateSchoolTypeMasterItem
{
    public class UpdateSchoolTypeCommand : IRequest<int>
    {
        public int schooltypeid { get; set; }
        public string typeofschool { get; set; }
        public string description { get; set; }
    }
    public class UpdateSchoolTypeCommandHandler : IRequestHandler<UpdateSchoolTypeCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public UpdateSchoolTypeCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(UpdateSchoolTypeCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_Schooltype.FindAsync(request.schooltypeid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(TypeOfSchoolEntities), request.typeofschool);
                }
                count = _context.m_master_Schooltype.Where(x => x.typeofschool == request.typeofschool && x.schooltypeid != request.schooltypeid && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.schooltypeid != 0)
                    {
                        entity.typeofschool = request.typeofschool;
                        entity.description = request.description;
                        entity.updatedby = 1;
                        entity.updatedon = _dateTime.Now;

                        bool hasSpecialChars = rgx.IsMatch(entity.typeofschool);
                        if (entity.description != null)
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                await _context.SaveChangesAsync(cancellationToken);
                                retval = 2;
                            }
                            else
                            {
                                retval = 403;
                            }
                        }

                        else if (hasSpecialChars == false)
                        {

                            await _context.SaveChangesAsync(cancellationToken);
                            retval = 2;
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
