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

namespace SRIS.Application.AidFreequencyMasters.Commands.DeleteAidFreequencyMasterItem
{
    public class DeleteAidFreequencyMasterCommand : IRequest<int>
    {
        public int id { get; set; }
    }
    public class DeleteAidFreequencyMasterCommandHandler : IRequestHandler<DeleteAidFreequencyMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteAidFreequencyMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteAidFreequencyMasterCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_aid_freequency.FindAsync(request.id);
            try
            {
                count = _context.t_hhr_incomesource.Where(x => x.freequencyofaidreceived == request.id && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Incomesource), request.id);
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
        //public async Task<Unit> Handle(DeleteAidFreequencyMasterCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.m_master_aid_freequency.FindAsync(request.id);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(AidFreequency), request.id);
        //    }

        //    _context.m_master_aid_freequency.Remove(entity);

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Unit.Value;
        //}

    }
}
