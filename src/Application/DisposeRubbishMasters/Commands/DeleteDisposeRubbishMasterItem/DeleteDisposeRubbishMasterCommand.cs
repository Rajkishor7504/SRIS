using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterDepenciesEntities;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.DisposeRubbishMasters.Commands.DeleteDisposeRubbishMasterItem
{
    public class DeleteDisposeRubbishMasterCommand : IRequest<int>
    {
        public int disposeid { get; set; }
    }
    public class DeleteMasterCommandHandler : IRequestHandler<DeleteDisposeRubbishMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteDisposeRubbishMasterCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_disposerubbish.FindAsync(request.disposeid);
            try
            {
                count = _context.t_hhr_housing.Where(x => x.f11_howhhdisposerubbish == request.disposeid && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Housing), request.disposeid);
                }
                if (count > 0)
                {
                    retval = 402;
                }
                else
                {
                    entity.updatedby = 1;
                    entity.deletedflag = true;
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
        //public async Task<Unit> Handle(DeleteDisposeRubbishMasterCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.m_master_disposerubbish.FindAsync(request.disposeid);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(DisposeRubbish), request.disposeid);
        //    }

        //    _context.m_master_disposerubbish.Remove(entity);

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Unit.Value;
        //}

    }
}