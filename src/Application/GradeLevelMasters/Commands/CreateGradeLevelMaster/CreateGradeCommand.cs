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

namespace SRIS.Application.GradeLevelMasters.Commands.CreateGradeLevelMaster
{
    public class CreateGradeCommand : IRequest<int>
    {
        public int gradeid { get; set; }
        public string gradename { get; set; }
       
        public string description { get; set; }
    }
    public class CreateGradeCommandHandler : IRequestHandler<CreateGradeCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateGradeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateGradeCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new GradeLevelMaster();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_grade.Where(x => x.gradename == request.gradename && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.gradeid == 0)
                    {
                        entity.gradename = request.gradename;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.deletedflag = false;
                        entity.gradeid = request.gradeid;
                        bool hasSpecialChars = rgx.IsMatch(entity.gradename);

                        if (entity.description != "")
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_grade.Add(entity);
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
                            _context.m_master_grade.Add(entity);
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
