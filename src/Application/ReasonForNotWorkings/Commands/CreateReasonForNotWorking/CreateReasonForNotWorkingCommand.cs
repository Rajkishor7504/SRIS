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

namespace SRIS.Application.ReasonForNotWorkings.Commands.CreateReasonForNotWorking
{
   public class CreateReasonForNotWorkingCommand:IRequest<int>
    {
        public int reasonid { get; set; }
        public string reasonname { get; set; }
        public string description { get; set; }
    }
    public class CreateReasonForNotWorkingCommandHandler : IRequestHandler<CreateReasonForNotWorkingCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public CreateReasonForNotWorkingCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(CreateReasonForNotWorkingCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new ReasonForNotWorking();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_reasonfornotworking.Where(x => x.reasonname == request.reasonname && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.reasonid == 0)
                    {
                        int id = _context.m_master_reasonfornotworking.ToListAsync().Result.LastOrDefault().reasonid;
                        entity.reasonname = request.reasonname;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.createdon = _dateTime.Now;
                        entity.deletedflag = false;
                        entity.reasonid = id + 1;
                        bool hasSpecialChars = rgx.IsMatch(entity.reasonname);
                        if (entity.description != "")
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_reasonfornotworking.Add(entity);

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

                            _context.m_master_reasonfornotworking.Add(entity);

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
