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

namespace SRIS.Application.RoffingMaterialCategoryMaster.Queries.GetRoffingMaterialCategoryMaster
{
   public class GetRoffingMaterialCategoryMasterQuery : IRequest<RoffingMaterialCategoryMasterVM>
    {
    }
    public class GetRoffingMaterialCategoryMasterQueryHandler : IRequestHandler<GetRoffingMaterialCategoryMasterQuery, RoffingMaterialCategoryMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRoffingMaterialCategoryMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RoffingMaterialCategoryMasterVM> Handle(GetRoffingMaterialCategoryMasterQuery request, CancellationToken cancellationToken)
        {
            return new RoffingMaterialCategoryMasterVM
            {
                Lists = await _context.m_master_roffingmaterialcategory
                    .ProjectTo<RoffingMaterialCategoryMasterDto>(_mapper.ConfigurationProvider)
                     .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.categoryid)
                    .ToListAsync(cancellationToken)
            };
        }
    }

}

