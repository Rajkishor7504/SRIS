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

namespace SRIS.Application.FlooringMaterialCategoryMaster.Queries.GetFlooringMaterialCategoryMaster
{
    public class GetFlooringMaterialCategoryMasterQuery : IRequest<FlooringMaterialCategoryMasterVM>
    {
    }
    public class GetFlooringMaterialCategoryMasterQueryHandler : IRequestHandler<GetFlooringMaterialCategoryMasterQuery, FlooringMaterialCategoryMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetFlooringMaterialCategoryMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FlooringMaterialCategoryMasterVM> Handle(GetFlooringMaterialCategoryMasterQuery request, CancellationToken cancellationToken)
        {
            return new FlooringMaterialCategoryMasterVM
            {
                Lists = await _context.m_master_flooringmaterialcategory
                    .ProjectTo<FlooringMaterialCategoryMasterDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.categoryid)
                    .ToListAsync(cancellationToken)
            };
        }
    }

}

