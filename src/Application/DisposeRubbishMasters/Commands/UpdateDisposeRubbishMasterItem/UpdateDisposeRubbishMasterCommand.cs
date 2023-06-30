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

namespace SRIS.Application.DisposeRubbishMasters.Commands.UpdateDisposeRubbishMasterItem
{
    public class UpdateDisposeRubbishMasterCommand : IRequest<int>
    {
        public int disposeid { get; set; }
        public string disposename { get; set; }
        public string description { get; set; }
        public class UpdateDisposeRubbishMasterCommandHandler : IRequestHandler<UpdateDisposeRubbishMasterCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public UpdateDisposeRubbishMasterCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateDisposeRubbishMasterCommand request, CancellationToken cancellationToken)
            {
                Regex rgx = new Regex("[^A-Za-z ]");
                int count = 0;
                int retval = 0;
                try
                {
                    var entity = await _context.m_master_disposerubbish.FindAsync(request.disposeid);


                    if (entity == null)
                    {
                        throw new NotFoundException(nameof(DisposeRubbish), request.disposename);
                    }
                    count = _context.m_master_disposerubbish.Where(x => x.disposename == request.disposename && x.disposeid != request.disposeid && x.deletedflag == false).Count();
                    if (count == 0)

                    {
                        if (request.disposeid != 0)
                        {
                            entity.disposename = request.disposename;
                            entity.description = request.description;
                            bool hasSpecialChars = rgx.IsMatch(entity.disposename);
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
