using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.AssignDevice.Queries
{
   public class GetAssignDeviceQuery : IRequest<AssignDeviceVM>
    {
        public string action { get; set; }
        public int searchid { get; set; }
    }
    public class GetAssignDeviceQueryHandler : IRequestHandler<GetAssignDeviceQuery, AssignDeviceVM>
    {
        private readonly IAssignedDeviceService _iAssignedDeviceService;
        private readonly IMapper _mapper;

        public GetAssignDeviceQueryHandler(IAssignedDeviceService iAssignedDeviceService, IMapper mapper)
        {
            _iAssignedDeviceService = iAssignedDeviceService;
            _mapper = mapper;
        }

        public async Task<AssignDeviceVM> Handle(GetAssignDeviceQuery request, CancellationToken cancellationToken)
        {
            var entity = new AssignDeviceDto();
            entity.action = request.action;
            entity.searchid = request.searchid;
            return new AssignDeviceVM
            {
                Lists = await _iAssignedDeviceService.GetAssignDevice(entity)
            };
        }
    }

}
