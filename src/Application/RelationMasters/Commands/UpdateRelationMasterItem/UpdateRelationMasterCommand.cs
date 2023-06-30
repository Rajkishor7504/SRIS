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

namespace SRIS.Application.RelationMasters.Commands.UpdateRelationMasterItem
{
    public class UpdateRelationMasterCommand : IRequest<int>
    {
        public int id { get; set; }
        public string relationname { get; set; }
        public string description { get; set; }
    }
    public class UpdateRelationMasterCommandHandler : IRequestHandler<UpdateRelationMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateRelationMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateRelationMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            int count = 0;
            int retval = 0;
            try
            {
                var entity = await _context.m_master_relation.FindAsync(request.id);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(RelationMaster), request.relationname);
                }
                count = _context.m_master_relation.Where(x => x.relationname == request.relationname && x.id != request.id && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.id != 0)
                    {
                        entity.relationname = request.relationname;
                        entity.description = request.description;

                        bool hasSpecialChars = rgx.IsMatch(entity.relationname);
                        if (entity.description != "")
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
