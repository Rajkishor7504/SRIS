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

namespace SRIS.Application.ReasonforNeverAttendSchools.Queries.GetReasonforNeverAttendSchoolQuery
{
    public class GetReasonforNeverAttendSchoolQuery : IRequest<ReasonforNeverAttendSchoolVM>
    {
        public int reasonId { get; set; }
    }
    public class GetReasonforNeverAttendSchoolQueryHandler : IRequestHandler<GetReasonforNeverAttendSchoolQuery, ReasonforNeverAttendSchoolVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetReasonforNeverAttendSchoolQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReasonforNeverAttendSchoolVM> Handle(GetReasonforNeverAttendSchoolQuery request, CancellationToken cancellationToken)
        {
            return new ReasonforNeverAttendSchoolVM
            {
                LISTS = await _context.m_master_reasonforneverattendschool
                    .ProjectTo<ReasonforNeverAttendSchoolDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.reason)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
