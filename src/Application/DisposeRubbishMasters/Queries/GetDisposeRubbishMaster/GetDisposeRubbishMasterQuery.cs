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

namespace SRIS.Application.DisposeRubbishMasters.Queries.GetDisposeRubbishMaster
{
    public class GetDisposeRubbishMasterQuery : IRequest<DisposeRubbishMasterVM>
    {
        public int disposeid { get; set; }
    }
    public class GetDisposeRubbishMasterQueryHandler : IRequestHandler<GetDisposeRubbishMasterQuery, DisposeRubbishMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDisposeRubbishMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DisposeRubbishMasterVM> Handle(GetDisposeRubbishMasterQuery request, CancellationToken cancellationToken)
        {
            return new DisposeRubbishMasterVM
            {
                Lists = await _context.m_master_disposerubbish
                    .ProjectTo<DisposeRubbishMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.disposename)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}