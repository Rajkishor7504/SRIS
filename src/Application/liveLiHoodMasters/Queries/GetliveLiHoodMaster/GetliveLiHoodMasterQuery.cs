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

namespace SRIS.Application.liveLiHoodMasters.Queries.GetliveLiHoodMaster
{
    public class GetliveLiHoodMasterQuery : IRequest<liveLiHoodMasterVM>
    {
        public int incomesourceid { get; set; }
    }
    public class GetliveLiHoodMasterQueryHandler : IRequestHandler<GetliveLiHoodMasterQuery, liveLiHoodMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetliveLiHoodMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<liveLiHoodMasterVM> Handle(GetliveLiHoodMasterQuery request, CancellationToken cancellationToken)
        {
            return new liveLiHoodMasterVM
            {
                Lists = await _context.m_master_livelihood
                    .ProjectTo<liveLiHoodMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.livelihoodname)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
