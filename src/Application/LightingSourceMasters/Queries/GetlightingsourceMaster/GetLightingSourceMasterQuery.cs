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

namespace SRIS.Application.LightingSourceMasters.Queries.GetlightingsourceMaster
{
    public class GetLightingSourceMasterQuery : IRequest<LightingSourceMasterVM> 
    {
        public int sourceid { get; set; }
    }
    public class GetLightingSourceMasterQueryHandler : IRequestHandler<GetLightingSourceMasterQuery, LightingSourceMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetLightingSourceMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LightingSourceMasterVM> Handle(GetLightingSourceMasterQuery request, CancellationToken cancellationToken)
        {
            return new LightingSourceMasterVM
            {
                Lists = await _context.m_master_lightingsource
                    .ProjectTo<LightingSourceMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.sourcename)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
