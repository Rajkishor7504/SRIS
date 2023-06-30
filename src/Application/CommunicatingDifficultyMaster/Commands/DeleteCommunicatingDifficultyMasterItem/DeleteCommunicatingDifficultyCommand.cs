﻿using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterDepenciesEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.CommunicatingDifficultyMaster.Commands.DeleteCommunicatingDifficultyMasterItem
{
  public  class DeleteCommunicatingDifficultyCommand : IRequest<int>
    {
        public int id { get; set; }
    }
    public class DeleteCommunicatingDifficultyCommandHandler : IRequestHandler<DeleteCommunicatingDifficultyCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCommunicatingDifficultyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteCommunicatingDifficultyCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_Communicatingdifficulty.FindAsync(request.id);
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
                    //_context.m_master_seeingdifficulty.Remove(entity);
                    //await _context.SaveChangesAsync(cancellationToken);
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
            //return Unit.Value;
            return retval;
        }
        //public async Task<Unit> Handle(DeleteSeeingDifficultyCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.m_master_seeingdifficulty.FindAsync(request.id);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(SeeingDifficulty), request.id);
        //    }

        //    _context.m_master_seeingdifficulty.Remove(entity);

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Unit.Value;
        //}
    }
}
