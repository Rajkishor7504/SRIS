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

namespace SRIS.Application.RelationsToProjectMasters.Commands.UpdateRelationsToProjectMasterItem
{
   public class UpdateRelationsToProjectMasterCommand : IRequest<int>
    {
        public int relationid { get; set; }
        public string relationname { get; set; }
        public string description { get; set; }
    }
    public class UpdateRelationsToProjectMasterCommandHandler : IRequestHandler<UpdateRelationsToProjectMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateRelationsToProjectMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateRelationsToProjectMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_relationofproject.FindAsync(request.relationid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(RelationsToProjectMaster), request.relationname);
                }
                count = _context.m_master_relationofproject.Where(x => x.relationname == request.relationname && x.relationid != request.relationid && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.relationid != 0)
                    {
                        entity.relationname = request.relationname;
                        entity.description = request.description;
                        bool hasSpecialChars = rgx.IsMatch(entity.relationname);
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
