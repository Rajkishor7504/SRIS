using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Masters.Queries.GetMaster
{
    public class GetMasterQuery : IRequest<MasterVm>
    {
        public string action { get; set; }
        public int parentid { get; set; }
        public int leveldetailid { get; set; }
        public int leveldtlsid { get; set; }
    }

    public class GetMasterQueryHandler : IRequestHandler<GetMasterQuery, MasterVm>
    {
        private readonly IMasterService _iMasterService;
        private readonly IMapper _mapper;

        public GetMasterQueryHandler(IMasterService iMasterService, IMapper mapper)
        {
            _iMasterService = iMasterService;
            _mapper = mapper;
        }

       
        public async Task<MasterVm> Handle(GetMasterQuery request, CancellationToken cancellationToken)
        {

            return new MasterVm
            {
                Lists = await _iMasterService.GetLevelDetails(request.action,request.parentid,request.leveldtlsid),
            };
        }
    }
}
