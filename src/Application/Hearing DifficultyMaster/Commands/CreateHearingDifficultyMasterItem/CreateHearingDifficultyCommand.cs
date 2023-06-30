using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Hearing_DifficultyMaster.Commands.CreateHearingDifficultyMasterItem
{
   public class CreateHearingDifficultyCommand : IRequest<int>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
    public class CreateHearingDifficultyCommandHandler : IRequestHandler<CreateHearingDifficultyCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public CreateHearingDifficultyCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(CreateHearingDifficultyCommand request, CancellationToken cancellationToken)
        {
            var entity = new HearingDifficulty();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_Hearingdifficulty.Where(x => x.name == request.name && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.id == 0)
                    {

                        entity.name = request.name;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.createdon = _dateTime.Now;
                        entity.deletedflag = false;
                        entity.id = request.id;
                        _context.m_master_Hearingdifficulty.Add(entity);
                        await _context.SaveChangesAsync(cancellationToken);
                        retval = 1;
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
