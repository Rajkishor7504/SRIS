using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.DisposeRubbishMasters.Commands.CreateDisposeRubbishMasterList
{
   public class CreateDisposeRubbishMasterCommand : IRequest<int>
    {
        public int disposeid { get; set; }
        public string disposename { get; set; }
        public string description { get; set; }
    }
    public class CreateDisposeRubbishMasterCommandHandler : IRequestHandler<CreateDisposeRubbishMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateDisposeRubbishMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateDisposeRubbishMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new DisposeRubbish();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_disposerubbish.Where(x => x.disposename == request.disposename && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.disposeid == 0)
                    {
                        entity.disposename = request.disposename;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.updatedby = 1;
                        entity.deletedflag = false;
                        entity.disposeid = request.disposeid;
                        bool hasSpecialChars = rgx.IsMatch(entity.disposename);
                        if (entity.description != null)
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_disposerubbish.Add(entity);
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

                            _context.m_master_disposerubbish.Add(entity);
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