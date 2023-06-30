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

namespace SRIS.Application.AssetsMasterItem.Queries.GetAssetsMasterQueries
{
    public class AssetsMasterqueries : IRequest<AssetsMasterVM>
    {
        public int assetid { get; set; }
    }
    public class GetResortFoodCopingQueryHandler : IRequestHandler<AssetsMasterqueries, AssetsMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetResortFoodCopingQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AssetsMasterVM> Handle(AssetsMasterqueries request, CancellationToken cancellationToken)
        {
            return new AssetsMasterVM
            {
                Lists = await _context.m_master_asset
                    .ProjectTo<AssetsMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.Assetname)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}

