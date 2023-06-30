using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterDepenciesEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SelfcareingdifficultyMaster.Command.DeleteSelfcareingdifficultyMasterItem
{
    public class DeleteSelfcareingdifficultyCommand : IRequest<int>
    {
        public int id { get; set; }
    }
    public class DeleteSelfcareingdifficultyCommandHandler : IRequestHandler<DeleteSelfcareingdifficultyCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteSelfcareingdifficultyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteSelfcareingdifficultyCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_Selfcareingdifficulty.FindAsync(request.id);
            try
            {
                count = _context.t_hhr_health.Where(x => x.d05a_dohavediffwearingglass == request.id && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Health), request.id);
                }
                if (count > 0)
                {
                    retval = 402;
                }
                else
                {
                    entity.updatedby = 1;
                    entity.deletedflag = true;
                    entity.updatedon = DateTime.Now;
                    await _context.SaveChangesAsync(cancellationToken);
                    retval = 200;
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

