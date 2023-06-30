using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SelfcareingdifficultyMaster.Command.UpdateSelfcareingdifficultyMasterItem
{
    public class UpdateSelfcareingdifficultyCommand : IRequest<int>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

    }
    public class UpdateSelfcareingdifficultyCommandHandler : IRequestHandler<UpdateSelfcareingdifficultyCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public UpdateSelfcareingdifficultyCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(UpdateSelfcareingdifficultyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.m_master_Selfcareingdifficulty.FindAsync(request.id);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Selfcareingdifficulty), request.name);
                }
                count = _context.m_master_Selfcareingdifficulty.Where(x => x.name == request.name && x.id != request.id && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.id != 0)
                    {

                        entity.name = request.name;
                        entity.description = request.description;
                        entity.updatedby = 1;
                        entity.updatedon = _dateTime.Now;
                        await _context.SaveChangesAsync(cancellationToken);
                        retval = 2;
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

