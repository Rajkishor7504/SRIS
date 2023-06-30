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

namespace SRIS.Application.AidTypeMasters.Queries.GetAidTypeMaster
{
    public class GetAidTypeMasterQuery : IRequest<AidTypeMasterVM>
    {
        public int aidid { get; set; }
    }
    public class GetAidTypeMasterQueryHandler : IRequestHandler<GetAidTypeMasterQuery, AidTypeMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAidTypeMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AidTypeMasterVM> Handle(GetAidTypeMasterQuery request, CancellationToken cancellationToken)
        {
            return new AidTypeMasterVM
            {
                Lists = await _context.m_hhr_aid
                    .ProjectTo<AidTypeMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.aidname)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
