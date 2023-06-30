using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.PMT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.PMT.PMTParameterMasterItem.Commands.DeletePMTParameterMasterItem
{
    public class DeletePMTParameterMasterCommand:IRequest<int>
    {
        public int parameterid { get; set; }
    }
    public class DeletePMTParameterMasterCommandHandler : IRequestHandler<DeletePMTParameterMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;
        public DeletePMTParameterMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeletePMTParameterMasterCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.t_pmt_pmtparameter.FindAsync(request.parameterid);
            try
            {
                count = _context.t_pmt_config_coefficient.Where(x => x.parameterid == request.parameterid && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(PMTParameterMaster), request.parameterid);
                }
                if (count > 0)
                    {
                        retval = 402;
                    }
                    else
                    {
                        _context.t_pmt_pmtparameter.Remove(entity);
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
