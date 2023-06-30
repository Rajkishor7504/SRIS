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

namespace SRIS.Application.GradeLevelMasters.Queries.GetGradeLevelMaster
{
   public class GetGradeMasterQuery: IRequest<GradeMasterVM>
    {
        public int gradeid { get; set; }
    }
    public class GetGradeMasterQueryHandler : IRequestHandler<GetGradeMasterQuery, GradeMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetGradeMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GradeMasterVM> Handle(GetGradeMasterQuery request, CancellationToken cancellationToken)
        {
            return new GradeMasterVM
            {
                Lists = await _context.m_master_grade
                    .ProjectTo<GradeMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.gradename)
                    .ToListAsync(cancellationToken)
            };
        }
    }
   
}
