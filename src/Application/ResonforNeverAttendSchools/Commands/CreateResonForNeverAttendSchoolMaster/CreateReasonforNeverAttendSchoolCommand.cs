using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.ReasonforNeverAttendSchools.Commands.CreateReasonForNeverAttendSchoolMaster
{
    public class CreateReasonforNeverAttendSchoolCommand : IRequest<int>
    {[Key]
        public int reasonid { get; set; }
        [Required]
        [MaxLength(50)]
        public string reason { get; set; }
        public string description { get; set; }

    }
    public class CreateReasonforNeverAttendSchoolCommandHandler : IRequestHandler<CreateReasonforNeverAttendSchoolCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateReasonforNeverAttendSchoolCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateReasonforNeverAttendSchoolCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new ResonforNeverAttendSchool();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_reasonforneverattendschool.Where(x =>x.reason == request.reason && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.reasonid == 0)
                    {
                        entity.reason = request.reason;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.updatedby = 1;
                        entity.deletedflag = false;
                        entity.reasonid = request.reasonid;
                        bool hasSpecialChars = rgx.IsMatch(entity.reason);
                        if (entity.description != "")
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_reasonforneverattendschool.Add(entity);
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

                            _context.m_master_reasonforneverattendschool.Add(entity);
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
