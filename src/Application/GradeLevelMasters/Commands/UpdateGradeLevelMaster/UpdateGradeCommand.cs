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

namespace SRIS.Application.GradeLevelMasters.Commands.UpdateGradeLevelMaster
{
    public class UpdateGradeCommand: IRequest<int>
    {
        public int gradeid { get; set; }
        public string gradename { get; set; }

        public string description { get; set; }
    }
    public class UpdateGradeCommandHandler : IRequestHandler<UpdateGradeCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateGradeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateGradeCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_grade.FindAsync(request.gradeid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(GradeLevelMaster), request.gradename);
                }
                count = _context.m_master_grade.Where(x => x.gradename == request.gradename && x.gradeid != request.gradeid && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.gradeid != 0)
                    {
                        entity.gradename = request.gradename;
                        entity.description = request.description;
                        bool hasSpecialChars = rgx.IsMatch(entity.gradename);
                        // entity.updatedby = 1;

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
