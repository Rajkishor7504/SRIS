using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.PrimaryLinkSlNoMasters.Queries.GetPrimayLinkSlNoMaster;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.PrimaryLinkSlNoMasters.Commands.UpdatePrimaryLinkMasterItem
{
    public class UpdatePrimaryLinkSlNoMasterCommand : IRequest<int>
    {
        public string action { get; set; }
        public int plinkid { get; set; }
        public int slno { get; set; }
        public int createdby { get; set; }
        public List<PrimayLinkSlNoMasterDto> Lists { get; set; }

    }
    public class UpdatePrimaryLinkSlNoMasterCommandHandler : IRequestHandler<UpdatePrimaryLinkSlNoMasterCommand, int>
    {
        private readonly IPrimaryLinkSlNoService _iPrimaryLinkSlNoService;

        public UpdatePrimaryLinkSlNoMasterCommandHandler(IPrimaryLinkSlNoService iPrimaryLinkSlNoService)
        {
            _iPrimaryLinkSlNoService = iPrimaryLinkSlNoService;
        }
        public async Task<int> Handle(UpdatePrimaryLinkSlNoMasterCommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
            var entity = new PrimayLinkSlNoMasterDto();
            try          
            {
              entity.action = request.action;
                entity.plinkid = request.plinkid;
                entity.slno = request.slno;
                entity.createdby = request.createdby;
                entity.Lists = request.Lists;
                retval = await _iPrimaryLinkSlNoService.UpdatePrimayLinkSlNo(entity);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return retval;
        }

    }
}
