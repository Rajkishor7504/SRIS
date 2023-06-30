using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.ReasonforNeverAttendSchools.Commands.UpdateReasornForNeverAttendSchoolMaster
{
    public class UpdateReasonforNeverAttendSchoolCommand : IRequest<int>
    {
        public int reasonId { get; set; }
        public string reason { get; set; }
        public string description { get; set; }

    }
    public class UpdateReasonforNeverAttendSchoolCommandHandler : IRequestHandler<UpdateReasonforNeverAttendSchoolCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateReasonforNeverAttendSchoolCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateReasonforNeverAttendSchoolCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_reasonforneverattendschool.FindAsync(request.reasonId);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(ResonforNeverAttendSchool), request.reason);
                }
                count = _context.m_master_reasonforneverattendschool.Where(x => x.reason == request.reason && x.reasonid != request.reasonId && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.reasonId != 0)
                    {
                        entity.reason = request.reason;
                        entity.description = request.description;


                        bool hasSpecialChars = rgx.IsMatch(entity.reason);
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
