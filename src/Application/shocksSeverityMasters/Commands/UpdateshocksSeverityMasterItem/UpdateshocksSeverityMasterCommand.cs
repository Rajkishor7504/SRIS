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

namespace SRIS.Application.shocksSeverityMasters.Commands.UpdateshocksSeverityMasterItem
{
    public class UpdateshocksSeverityMasterCommand : IRequest<int>
    {
        public int severityid { get; set; }
        public string severityname { get; set; }
        public string description { get; set; }
    }
    public class UpdateshocksSeverityMasterCommandHandler : IRequestHandler<UpdateshocksSeverityMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateshocksSeverityMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateshocksSeverityMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_severity.FindAsync(request.severityid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(shocksSeverityMaster), request.severityname);
                }
                count = _context.m_master_severity.Where(x => x.severityname == request.severityname && x.severityid != request.severityid && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.severityid != 0)
                    {
                        entity.severityname = request.severityname;
                        entity.description = request.description;
                        bool hasSpecialChars = rgx.IsMatch(entity.severityname);
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
