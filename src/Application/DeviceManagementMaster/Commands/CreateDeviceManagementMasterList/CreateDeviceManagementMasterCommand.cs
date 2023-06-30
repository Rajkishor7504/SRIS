using MediatR;
using Microsoft.Extensions.Logging;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.LoginAuthentication;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.DeviceManagementMaster.Commands.CreateDeviceManagementMasterList
{
    public class CreateDeviceManagementMasterCommand : IRequest<int>
    {
        public int deviceconfigid { get; set; }
        public string description { get; set; }
        public string deviceimeinumber { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public DateTime dateofpurchase { get; set; }

    }
    public class CreateDeviceManagementMasterCommandHandler : IRequestHandler<CreateDeviceManagementMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;
       // private readonly ILogger _logger;

        public CreateDeviceManagementMasterCommandHandler(IApplicationDbContext context )
        {
            _context = context;
          //  _logger = logger;
        }
        public async Task<int> Handle(CreateDeviceManagementMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = new DeviceMngtMaster();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_deviceconfig.Where(x => x.deviceimeinumber == request.deviceimeinumber).Count();
                if (count == 0)
                {
                    if (request.deviceconfigid == 0)
                    {
                        entity.make = request.make;
                        entity.model = request.model;
                        entity.dateofpurchase = request.dateofpurchase;
                        entity.deviceimeinumber = request.deviceimeinumber;
                        entity.description = request.description;
                        entity.createdby = 1;
                        _context.m_master_deviceconfig.Add(entity);
                        await _context.SaveChangesAsync(cancellationToken);
                        retval = 1;
                    }
                }
                else 
                {
                    retval = 3;
                }
               

            }
            catch (System.Exception ex)
            {
                if(ex.InnerException.Message == "Data too long for column 'make' at row 1")
                {
                    retval = 4;
                }
                else
                {
                    throw ex;
                   
                }
                
            }

            return retval;

        }
    }
}
