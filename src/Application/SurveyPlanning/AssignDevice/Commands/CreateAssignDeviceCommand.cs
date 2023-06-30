using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.SurveyPlanning.AssignDevice.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.AssignDevice.Commands
{
   public class CreateAssignDeviceCommand : IRequest<int>
    {
        public string action { get; set; }
        public int planid { get; set; }
        public int regionid { get; set; }
        public int usertypeid { get; set; }
        public int userid { get; set; }
        public int deviceid { get; set; }
        public int createdby { get; set; }
        public int deviceassignid { get; set; }
        public List<AssignDeviceDto> Lists { get; set; }

    }
    public class CreateAssignDeviceCommandHandler : IRequestHandler<CreateAssignDeviceCommand, int>
    {
        private readonly IAssignedDeviceService _iAssignedDeviceService;

        public CreateAssignDeviceCommandHandler(IAssignedDeviceService iAssignedDeviceService)
        {
            _iAssignedDeviceService = iAssignedDeviceService;
        }

        public async Task<int> Handle(CreateAssignDeviceCommand request, CancellationToken cancellationToken)
        {
            var entity = new AssignDeviceDto();
            int retval = 0;
            try
            {
                    entity.action = request.action;
                    entity.deviceassignid = request.deviceassignid;
                if (request.Lists.Count > 0)
                {
                    entity.planid = request.Lists[0].planid;
                    entity.regionid = request.Lists[0].clusterno;
                }
                
                    entity.createdby = request.createdby;
                    entity.Lists = request.Lists;
                retval = await _iAssignedDeviceService.AssignDevice(entity);          
            }

            catch(Exception ex)
            {
                throw ex;
            }

            return retval;

        }
    }

}
