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

namespace SRIS.Application.WorkingFrequencyMasters.Commands.DeleteWorkingFrequencyMater
{
    public class DeleteWorkingFrequencyCommand:IRequest<int>
    {
        public int id { get; set; }
    }
    public class DeleteWorkingFrequencyCommandHandler : IRequestHandler<DeleteWorkingFrequencyCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteWorkingFrequencyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteWorkingFrequencyCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_workingfreequency.FindAsync(request.id);
            try
            {
                count = _context.t_hhr_employment.Where(x => x.e03_howfreequentlyworking == request.id && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Employment), request.id);
                }
                if (count > 0)
                {
                    retval = 402;
                }
                else
                {
                    //_context.m_master_workingfreequency.Remove(entity);
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
        //public async Task<Unit> Handle(DeleteWorkingFrequencyCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.m_master_workingfreequency.FindAsync(request.id);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(WorkingFreequency), request.id);
        //    }

        //    _context.m_master_workingfreequency.Remove(entity);

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Unit.Value;
        //}
    }
}
