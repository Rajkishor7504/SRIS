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

namespace SRIS.Application.WorkingStatusMaster.Commands.UpdateWorkingStatusMaster
{
   public class UpdateWorkingStatusCommand:IRequest<int>
    {
        public int statusid { get; set; }
        public string statusname { get; set; }
        public string description { get; set; }
    }
    public class UpdateWorkingStatusCommandHandler : IRequestHandler<UpdateWorkingStatusCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public UpdateWorkingStatusCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(UpdateWorkingStatusCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_workingstatus.FindAsync(request.statusid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(WorkingStatus), request.statusname);
                }
                count = _context.m_master_workingstatus.Where(x => x.statusname == request.statusname && x.statusid != request.statusid && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.statusid != 0)
                    {
                        entity.statusname = request.statusname;
                        entity.description = request.description;
                        entity.updatedby = 1;
                        entity.updatedon = _dateTime.Now;

                        bool hasSpecialChars = rgx.IsMatch(entity.statusname);
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

