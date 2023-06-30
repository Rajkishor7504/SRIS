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

namespace SRIS.Application.CopingTypeMaster.Queries.GetCopingTypeQuery
{
    public class GetCopingTypeMasterQuery : IRequest<CopingTypeMasterVM>
    {
        public int copingtypeid { get; set; }
    }
    public class GetCopingTypeMasterQueryHandler : IRequestHandler<GetCopingTypeMasterQuery, CopingTypeMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCopingTypeMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CopingTypeMasterVM> Handle(GetCopingTypeMasterQuery request, CancellationToken cancellationToken)
        {
            return new CopingTypeMasterVM
            {
                Lists = await _context.m_master_copingtype
                    .ProjectTo<CopingTypeMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.copingtypename)
                    .ToListAsync(cancellationToken)
            };
        }

    }

}
