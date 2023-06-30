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

namespace SRIS.Application.OrganizatonTypeMasters.Queries.GetOrganizatonTypeMaster
{
    public class GetOrganizatonTypeMasterQuery : IRequest<OrganizatonTypeMasterVM>
    {
        public int organizationtypeid { get; set; }
    }
    public class GetOrganizatonTypeMasterQueryHandler : IRequestHandler<GetOrganizatonTypeMasterQuery, OrganizatonTypeMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetOrganizatonTypeMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrganizatonTypeMasterVM> Handle(GetOrganizatonTypeMasterQuery request, CancellationToken cancellationToken)
        {
            return new OrganizatonTypeMasterVM
            {
                Lists = await _context.m_master_organizatontype
                    .ProjectTo<OrganizatonTypeMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.organizationtypename)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
