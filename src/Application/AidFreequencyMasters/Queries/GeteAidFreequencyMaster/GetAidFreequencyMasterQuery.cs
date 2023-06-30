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

namespace SRIS.Application.AidFreequencyMasters.Queries.GeteAidFreequencyMaster
{
    public class GetAidFreequencyMasterQuery : IRequest<AidFreequencyMasterVM>
    {
        public int id { get; set; }
    }
    public class GetAidFreequencyMasterQueryHandler : IRequestHandler<GetAidFreequencyMasterQuery, AidFreequencyMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAidFreequencyMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AidFreequencyMasterVM> Handle(GetAidFreequencyMasterQuery request, CancellationToken cancellationToken)
        {
            return new AidFreequencyMasterVM
            {
                Lists = await _context.m_master_aid_freequency
                    .ProjectTo<AidFreequencyMasterDto>(_mapper.ConfigurationProvider)
                     .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.name)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}