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

namespace SRIS.Application.EcologyMaster.Commands.CreateEcologyTypeMasterItem
{
    public class CreateEcologyTypeCommand : IRequest<int>
    {
        public int type_id { get; set; }
        public string type_name { get; set; }
    }
    public class CreateEcologyTypeCommandHandler : IRequestHandler<CreateEcologyTypeCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _datetime;

        public CreateEcologyTypeCommandHandler(IApplicationDbContext context, IDateTime datetime)
        {
            _context = context;
            _datetime = datetime;
        }

        public async Task<int> Handle(CreateEcologyTypeCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new EcologyMasterEntity();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_typeofecology.Where(x => x.type_name == request.type_name && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.type_id == 0)
                    {
                        int id = _context.m_master_typeofecology.ToListAsync().Result.LastOrDefault().type_id;
                        entity.type_name = request.type_name;
                        entity.createdby = 1;
                        entity.createdon = _datetime.Now;
                        entity.deletedflag = false;
                        entity.type_id = id + 1;
                        bool hasSpecialChars = rgx.IsMatch(entity.type_name);
                        if (hasSpecialChars == false)
                        {
                            _context.m_master_typeofecology.Add(entity);
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
