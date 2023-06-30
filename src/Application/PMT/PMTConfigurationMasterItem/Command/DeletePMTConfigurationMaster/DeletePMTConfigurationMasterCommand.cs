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

namespace SRIS.Application.PMT.PMTConfigurationMasterItem.Command.DeletePMTConfigurationMaster
{
    public class DeletePMTConfigurationMasterCommand: IRequest <int>
    {
        public int pmtconfigureid { get; set; }
        //public int pmtconfigureid { get; set; }
    }
    public class DeletePMTConfigurationMasterCommandHandler : IRequestHandler<DeletePMTConfigurationMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public DeletePMTConfigurationMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeletePMTConfigurationMasterCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            //var val = request.pmtconfigureid;
            var entity = await _context.t_pmt_configuration.FindAsync(request.pmtconfigureid);
            
            var entity1 =  _context.t_pmt_config_coefficient.Where(s=>s.pmtconfigureid== request.pmtconfigureid).ToList();
            try
            {
                count = _context.t_pmt_config_coefficient.Where(x => x.pmtconfigureid == request.pmtconfigureid && x.deletedflag == false).Count();
                if (entity == null)
                {

                    throw new NotFoundException(nameof(PMTConfigurationMaster), request.pmtconfigureid);

                }
                if (count > 0)
                {
                    retval = 402;
                }
                else
                {
                    _context.t_pmt_configuration.Remove(entity);
                    foreach (var lst in entity1)
                    {
                        _context.t_pmt_config_coefficient.Remove(lst);                       
                    }
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
