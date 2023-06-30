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

namespace SRIS.Application.ReasonForStopSchools.Queries.GetReasonForStopSchoolQueryMaster
{
    public class GetReasonForStopSchoolQuery: IRequest<ReasonForStopSchoolVM>
    {
        public int reasonid { get; set; }
    }
    public class GetReasonForStopSchoolQueryHandler : IRequestHandler<GetReasonForStopSchoolQuery, ReasonForStopSchoolVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetReasonForStopSchoolQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReasonForStopSchoolVM> Handle(GetReasonForStopSchoolQuery request, CancellationToken cancellationToken)
        {
            return new ReasonForStopSchoolVM
            {
                Lists = await _context.m_master_reasonforstopschool
                    .ProjectTo<ReasonForStopSchoolDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.reason)
                    .ToListAsync(cancellationToken)
            };
        }
   
    }
}
