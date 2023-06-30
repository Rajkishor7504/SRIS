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

namespace SRIS.Application.IncomeSourceMasters.Commands.DeleteIncomeSourceMasterItem
{
    public class DeleteIncomeSourceMasterCommand : IRequest<int>
    {
        public int incomesourceid { get; set; }
    }
    public class DeleteIncomeSourceMasterCommandHandler : IRequestHandler<DeleteIncomeSourceMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteIncomeSourceMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteIncomeSourceMasterCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_incomesource.FindAsync(request.incomesourceid);
            try
            {
                count = _context.t_hhr_incomesource.Where(x => x.mainincomesourceofhh == request.incomesourceid && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Incomesource), request.incomesourceid);
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
        //public async Task<Unit> Handle(DeleteIncomeSourceMasterCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.m_master_incomesource.FindAsync(request.incomesourceid);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(MainIncomeSource), request.incomesourceid);
        //    }

        //    _context.m_master_incomesource.Remove(entity);
        //    //entity.updatedon = DateTime.Now;
        //    //entity.deletedflag = true;

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Unit.Value;
        //}

    }
}