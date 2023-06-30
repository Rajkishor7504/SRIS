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

namespace SRIS.Application.EcologyMaster.Commands.UpdateEcologyTypeMasterItem
{
    public class UpdateEcologyTypeCommand : IRequest<int>
    {
        public int type_id { get; set; }
        public string type_name { get; set; }
    }
    public class UpdateEcologyTypeCommandHandler : IRequestHandler<UpdateEcologyTypeCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;


        public UpdateEcologyTypeCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _dateTime = dateTime;
            _context = context;
        }    
        public async Task<int> Handle(UpdateEcologyTypeCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_typeofecology.FindAsync(request.type_id);
            int count = 0;
            int retval = 0;

            if (entity == null)
            {
                throw new NotFoundException(nameof(EcologyMasterEntity), request.type_name);
            }
            count = _context.m_master_typeofecology.Where(x => x.type_name == request.type_name && x.type_id != request.type_id && x.deletedflag == false).Count();
            if (count == 0)
            {
                if (request.type_id != 0)
                {
                    entity.updatedon = _dateTime.Now;
                    entity.updatedby = 1;
                    entity.type_name = request.type_name;
                    bool hasSpecialChars = rgx.IsMatch(entity.type_name);
                    if (hasSpecialChars == false)
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

            return retval;
        }
    }
}
