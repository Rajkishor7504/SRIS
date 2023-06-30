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

namespace SRIS.Application.CookingFuelMaster.Queries.GetCookingFuelMaster
{
    public class GetCookingFuelMasterQuery : IRequest<CookingFuelMasterVM>
    {
        public int fuelid { get; set; }
    }
    public class GetCookingFuelMasterQueryHandler : IRequestHandler<GetCookingFuelMasterQuery, CookingFuelMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCookingFuelMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CookingFuelMasterVM> Handle(GetCookingFuelMasterQuery request, CancellationToken cancellationToken)
        {
            return new CookingFuelMasterVM
            {
                Lists = await _context.m_master_cookingfuel
                    .ProjectTo<CookingFuelMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.fuelname)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}