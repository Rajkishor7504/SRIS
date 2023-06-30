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

namespace SRIS.Application.NationalityMasters.Queries.GetNationalityMaster
{
    public class GetNationalityMasterQuery : IRequest<NationalityMasterVM>
    {
        public int nationalityid { get; set; }
    }
    public class GetNationalityMasterQueryHandler : IRequestHandler<GetNationalityMasterQuery, NationalityMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetNationalityMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<NationalityMasterVM> Handle(GetNationalityMasterQuery request, CancellationToken cancellationToken)
        {
            return new NationalityMasterVM
            {
                Lists = await _context.m_master_nationalitytbl
                    .ProjectTo<NationalityMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.nationality)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
