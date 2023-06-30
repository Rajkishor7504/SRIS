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

namespace SRIS.Application.ResidenceMasters.Queries.GetResidenceMaster
{
    public class GetResidenceMasterQuery : IRequest<ResidenceMasterVM>
    {
        public int id { get; set; }
    }
    public class GetResidenceMasterQueryHandler : IRequestHandler<GetResidenceMasterQuery, ResidenceMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetResidenceMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResidenceMasterVM> Handle(GetResidenceMasterQuery request, CancellationToken cancellationToken)
        {
            return new ResidenceMasterVM
            {
                Lists = await _context.M_Master_Residence
                    .ProjectTo<ResidenceMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.residencename)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
