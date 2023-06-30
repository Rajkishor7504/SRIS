using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.DeviceManagementMaster.Commands.UpdateDeviceMasterItem
{
    public class UpdateDeviceMasterCommand : IRequest<int>
    {
        public int deviceconfigid { get; set; }
        public string description { get; set; }
        public string deviceimeinumber { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public DateTime dateofpurchase { get; set; }
        public int assignedstatus { get; set; }
    }
    public class UpdateDeviceMasterCommandHandler : IRequestHandler<UpdateDeviceMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public UpdateDeviceMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateDeviceMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.m_master_deviceconfig.FindAsync(request.deviceconfigid);
            int count = 0;
            int retval = 0;
            int intDeviceCount = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(DeviceManagementMaster), request.make);
                }
                count = _context.m_master_deviceconfig.Where(x => x.deviceimeinumber == request.deviceimeinumber && x.deviceconfigid != request.deviceconfigid).Count();
                intDeviceCount = _context.t_survey_assigneddevice.Where(x => x.deviceid == request.deviceconfigid && x.deletedflag == false).Count();

                if (intDeviceCount > 0)
                {
                    retval = 402;
                }
                else
                {
                    if (count == 0)
                    {
                        if (request.deviceconfigid != 0)
                        {
                            if (request.assignedstatus != 0)
                            {
                                entity.assignedstatus = request.assignedstatus;
                                await _context.SaveChangesAsync(cancellationToken);
                                retval = 4;
                            }
                            else
                            {
                                entity.make = request.make;
                                entity.model = request.model;
                                entity.dateofpurchase = request.dateofpurchase;
                                entity.description = request.description;
                                entity.deviceimeinumber = request.deviceimeinumber;

                                await _context.SaveChangesAsync(cancellationToken);
                                retval = 2;

                            }
                        }
                    }
                    else
                    {
                        retval = 3;
                    }
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
