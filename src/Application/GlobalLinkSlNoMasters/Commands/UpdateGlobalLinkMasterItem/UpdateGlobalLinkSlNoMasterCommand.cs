using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.GlobalLinkSlNoMasters.Queries.GetGlobalLinkSlNoMaster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.GlobalLinkSlNoMasters.Commands.UpdateGlobalLinkMasterItem
{
    public class UpdateGlobalLinkSlNoMasterCommand : IRequest<int>
    {
        public string action { get; set; }
        public int glinkid { get; set; }
        public int gslno { get; set; }
        public int createdby { get; set; }
        public List<GlobalLinkSlNoMasterDto> Lists { get; set; }

    }
    public class UpdateGlobalLinkSlNoMasterCommandHandler : IRequestHandler<UpdateGlobalLinkSlNoMasterCommand, int>
    {
        private readonly IGlobalLinkSlNoService _iGlobalLinkSlNoService;

        public UpdateGlobalLinkSlNoMasterCommandHandler(IGlobalLinkSlNoService iGlobalLinkSlNoService)
        {
            _iGlobalLinkSlNoService = iGlobalLinkSlNoService;
        }
        public async Task<int> Handle(UpdateGlobalLinkSlNoMasterCommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
            var entity = new GlobalLinkSlNoMasterDto();
            try
            {
                entity.action = request.action;
                entity.glinkid = request.glinkid;
                entity.gslno = request.gslno;
                entity.createdby = request.createdby;
                entity.Lists = request.Lists;
                retval = await _iGlobalLinkSlNoService.UpdateGlobalLinkSlNo(entity);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return retval;
        }

    }
}
