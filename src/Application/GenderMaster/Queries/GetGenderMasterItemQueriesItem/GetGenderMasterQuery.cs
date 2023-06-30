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

namespace SRIS.Application.GenderMaster.Queries.GetGenderMasterItemQueriesItem
{
    public  class GetGenderMasterQuery : IRequest<GenderMasterVM>
    {
        public int genderid { get; set; }
    }
    public class GetGenderMasterQueryHandler : IRequestHandler<GetGenderMasterQuery, GenderMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetGenderMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GenderMasterVM> Handle(GetGenderMasterQuery request, CancellationToken cancellationToken)
        {
            return new GenderMasterVM
            {
                Lists = await _context.m_master_gender
                    .ProjectTo<GenderMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.gendername)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}


