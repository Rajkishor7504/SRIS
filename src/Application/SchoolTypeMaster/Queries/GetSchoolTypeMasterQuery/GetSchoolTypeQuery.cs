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

namespace SRIS.Application.SchoolTypeMaster.Queries.GetSchoolTypeMasterQuery
{
   public class GetSchoolTypeQuery : IRequest<SchoolTypeMasterVM>
    {
        public int schooltypeid { get; set; }
    }
    public class GetSchoolTypeQueryHandler : IRequestHandler<GetSchoolTypeQuery, SchoolTypeMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSchoolTypeQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SchoolTypeMasterVM> Handle(GetSchoolTypeQuery request, CancellationToken cancellationToken)
        {
            return new SchoolTypeMasterVM
            {
                Lists = await _context.m_master_Schooltype
                    .ProjectTo<SchoolTypeMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.typeofschool)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
