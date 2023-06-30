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

namespace SRIS.Application.WallCategoryMasters.Queries.GetWallCategoryMaster
{
    public class GetWallCategoryMasterQuery : IRequest<WallCategoryMasterVM>
    {
    }
    public class GetWallCategoryMasterQueryHandler : IRequestHandler<GetWallCategoryMasterQuery, WallCategoryMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetWallCategoryMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WallCategoryMasterVM> Handle(GetWallCategoryMasterQuery request, CancellationToken cancellationToken)
        {
            return new WallCategoryMasterVM
            {
                Lists = await _context.m_master_wallcategory
                    .ProjectTo<WallCategoryMasterDto>(_mapper.ConfigurationProvider)
                     .Where(t=>t.deletedflag==false)
                    .OrderBy(t => t.categoryid)
                    .ToListAsync(cancellationToken)
            };
        }
    }

}
