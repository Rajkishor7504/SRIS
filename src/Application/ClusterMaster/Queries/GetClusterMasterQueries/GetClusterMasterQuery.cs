using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.ClusterMaster.Queries.GetClusterMasterQueries
{
    public class GetClusterMasterQuery : IRequest<ClusterMasterVM>
    {
        public string action { get; set; }
        public int parentid { get; set; }
        public int id { get; set; }
    }
    public class GetClusterMasterQueryHandler : IRequestHandler<GetClusterMasterQuery, ClusterMasterVM>
    {
        private readonly IClusterMasterService _iClusterMasterService;
        private readonly IMapper _mapper;

        public GetClusterMasterQueryHandler(IClusterMasterService iClusterMasterService, IMapper mapper)
        {
            _iClusterMasterService = iClusterMasterService;
            _mapper = mapper;
        }


        public async Task<ClusterMasterVM> Handle(GetClusterMasterQuery request, CancellationToken cancellationToken)
        {

            return new ClusterMasterVM
            {
                Lists = await _iClusterMasterService.GetLevelDetails(request.action, request.parentid,request.id),
            };
        }
    }
}
