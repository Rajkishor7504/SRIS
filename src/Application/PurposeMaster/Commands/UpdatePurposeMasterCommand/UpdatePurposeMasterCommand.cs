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

namespace SRIS.Application.PurposeMaster.Commands.UpdatePurposeMasterCommand
{
   public class UpdatePurposeMasterCommand : IRequest<int>
    {
        public int purposeid { get; set; }
        public string purposename { get; set; }
        public string description { get; set; }
        public class UpdatePurposeMasterCommandHandler : IRequestHandler<UpdatePurposeMasterCommand, int>
        {
            private readonly IApplicationDbContext _context;
            private readonly IDateTime _dateTime;


            public UpdatePurposeMasterCommandHandler(IApplicationDbContext context, IDateTime dateTime)
            {
                _context = context;
                _dateTime = dateTime;
            }

            public async Task<int> Handle(UpdatePurposeMasterCommand request, CancellationToken cancellationToken)
            {
                Regex rgx = new Regex("[^A-Za-z ]");
                int count = 0;
                int retval = 0;
                try
                {
                    var entity = await _context.m_master_purpose.FindAsync(request.purposeid);


                    if (entity == null)
                    {
                        throw new NotFoundException(nameof(Purpose), request.purposename);
                    }
                    count = _context.m_master_purpose.Where(x => x.purposename == request.purposename && x.purposeid != request.purposeid && x.deletedflag == false).Count();
                    if (count == 0)

                    {
                        if (request.purposeid != 0)
                        {
                            entity.updatedon = _dateTime.Now;
             
                            entity.purposename = request.purposename;
                            entity.updatedby = 1;
                            entity.description = request.description;
                            bool hasSpecialChars = rgx.IsMatch(entity.purposename);
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
}