using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.DeviceManagementMaster.Commands.DeleteDeviceMasterItem
{
    public class DeleteDeviceMasterCommand : IRequest<int>
    {
        public int deviceconfigid { get; set; }
    }

    public class DeleteDeviceMasterCommandHandler : IRequestHandler<DeleteDeviceMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteDeviceMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteDeviceMasterCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_deviceconfig.FindAsync(request.deviceconfigid);
            try { 
            count = _context.t_survey_assigneddevice.Where(x => x.deviceid == request.deviceconfigid && x.deletedflag == false).Count();

            if (entity == null)
            {
                throw new NotFoundException(nameof(DeviceMngtMaster), request.deviceconfigid);
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
            catch(System.Exception ex)
            {
                throw ex;
            }
            return retval;
        }
    }
}
