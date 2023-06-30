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

namespace SRIS.Application.ReasonForNotWorkings.Commands.UpdateReasonForNotWorking
{
    public class UpdateReasonForNotWorkingCommand:IRequest<int>
    {
        public int reasonid { get; set; }
        public string reasonname { get; set; }
        public string description { get; set; }

    }
    public class UpdateReasonForNotWorkingCommandHandler : IRequestHandler<UpdateReasonForNotWorkingCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public UpdateReasonForNotWorkingCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(UpdateReasonForNotWorkingCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_reasonfornotworking.FindAsync(request.reasonid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(ReasonForNotWorking), request.reasonname);
                }
                count = _context.m_master_reasonfornotworking.Where(x => x.reasonname == request.reasonname && x.reasonid != request.reasonid && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.reasonid != 0)
                    {
                        entity.reasonname = request.reasonname;
                        entity.description = request.description;
                        entity.updatedby = 1;
                        entity.updatedon = _dateTime.Now;


                        bool hasSpecialChars = rgx.IsMatch(entity.reasonname);
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

