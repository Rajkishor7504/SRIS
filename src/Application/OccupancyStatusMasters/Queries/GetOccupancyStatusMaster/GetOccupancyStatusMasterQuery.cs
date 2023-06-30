using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.OccupancyStatusMasters.Queries.GetOccupancyStatusMaster
{
  public class GetOccupancyStatusMasterQuery : IRequest<OccupancyStatusMasterVM>
    {
        public int id { get; set; }
    }
    public class GetOccupancyStatusMasterQueryHandler : IRequestHandler<GetOccupancyStatusMasterQuery, OccupancyStatusMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetOccupancyStatusMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OccupancyStatusMasterVM> Handle(GetOccupancyStatusMasterQuery request, CancellationToken cancellationToken)
        {
            return new OccupancyStatusMasterVM
            {
                Lists = await _context.m_master_occupancyStatus
                    .ProjectTo<OccupancyStatusMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.occupancyStatusName)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
