using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Masters.Queries.GetMaster
{
  public  class GetMasterFilterQuery : IRequest<MasterVm>
    {
        public string action { get; set; }
        public int parentid { get; set; }
        public int leveldetailid { get; set; }
        public int id { get; set; }
    }
    public class GetMasterFilterQueryHandler : IRequestHandler<GetMasterFilterQuery, MasterVm>
    {
        private readonly IMasterService _iMasterService;
        private readonly IMapper _mapper;

        public GetMasterFilterQueryHandler(IMasterService iMasterService, IMapper mapper)
        {
            _iMasterService = iMasterService;
            _mapper = mapper;
        }


        public async Task<MasterVm> Handle(GetMasterFilterQuery request, CancellationToken cancellationToken)
        {
            return new MasterVm
            {
                Lists = await _iMasterService.GetLevelData(request.action, request.parentid, request.leveldetailid,request.id),
            };
        }
    }
}
