using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.LightingSourceMasters.Queries.GetlightingsourceMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.DrinkingSourceMaster.Queries.GetDrinkingSourceMaster
{
   public class GetDrinkingSourceMasterQuery : IRequest<DrinkingSourceMasterVM>
    {
        public int sourceid { get; set; }
    }
    public class GetDrinkingSourceMasterQueryHandler : IRequestHandler<GetDrinkingSourceMasterQuery, DrinkingSourceMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDrinkingSourceMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DrinkingSourceMasterVM> Handle(GetDrinkingSourceMasterQuery request, CancellationToken cancellationToken)
        {
            return new DrinkingSourceMasterVM
            {
                Lists = await _context.m_master_drinkingsource
                    .ProjectTo<DrinkingSourceMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.sourcename)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
