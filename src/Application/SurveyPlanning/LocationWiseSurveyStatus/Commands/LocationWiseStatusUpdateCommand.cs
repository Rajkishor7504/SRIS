using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.SurveyPlanning.LocationWiseSurveyStatus.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.LocationWiseSurveyStatus.Commands
{
   public class LocationWiseStatusUpdateCommand : IRequest<int>
    {
        public string action { get; set; }
        public int planid { get; set; }
        public int regionid { get; set; }
        public int distid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
        public int status { get; set; }
        public int createdby { get; set; }
    }
    public class LocationWiseStatusUpdateCommandHandler : IRequestHandler<LocationWiseStatusUpdateCommand, int>
    {
        private readonly ILocationStatusUpdateService _iLocationStatusUpdateService;

        public LocationWiseStatusUpdateCommandHandler(ILocationStatusUpdateService iLocationStatusUpdateService)
        {
            _iLocationStatusUpdateService = iLocationStatusUpdateService;
        }

        public async Task<int> Handle(LocationWiseStatusUpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = new StatusUpdateDto();
            int retval = 0;
            try
            {
                    entity.action = request.action;
                    entity.planid = request.planid;
                    entity.regionid = request.regionid;
                    entity.distid = request.distid;
                    entity.wardid = request.wardid;
                    entity.settlementid = request.settlementid;
                    entity.status = request.status;
                    entity.createdby = request.createdby;
                    entity.createdby = request.createdby;
                    retval = await _iLocationStatusUpdateService.UpdateStatus(entity);
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return retval;

        }
    }

}
