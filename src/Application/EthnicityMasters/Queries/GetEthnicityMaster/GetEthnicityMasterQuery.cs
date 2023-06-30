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

namespace SRIS.Application.EthnicityMasters.Queries.GetEthnicityMaster
{
   public class GetEthnicityMasterQuery : IRequest<EthnicityMasterVM>
    {
        public int ethnicityid { get; set; }
    }
    public class GetEthnicityMasterQueryHandler : IRequestHandler<GetEthnicityMasterQuery, EthnicityMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetEthnicityMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EthnicityMasterVM> Handle(GetEthnicityMasterQuery request, CancellationToken cancellationToken)
        {
            return new EthnicityMasterVM
            {
                Lists = await _context.m_master_ethnicity
                    .ProjectTo<EthnicityMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.ethnicityname)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
