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

namespace SRIS.Application.ResortLivelihoodCopingMaster.Queries.GetResortLivelihoodCopingMasterQuery
{
    public class GetResortLivelihoodCopingQuery : IRequest<ResortLivelihoodCopingMasterVM>
    {
        public int resortlivelyhoodcopingid { get; set; }
    }
    public class GetResortLivelihoodCopingQueryHandler : IRequestHandler<GetResortLivelihoodCopingQuery, ResortLivelihoodCopingMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetResortLivelihoodCopingQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResortLivelihoodCopingMasterVM> Handle(GetResortLivelihoodCopingQuery request, CancellationToken cancellationToken)
        {
            return new ResortLivelihoodCopingMasterVM
            {
                Lists = await _context.m_master_resortLivelhoodCoping
                    .ProjectTo<ResortLivelihoodCopingMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.resortlivelyhoodcoping)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
