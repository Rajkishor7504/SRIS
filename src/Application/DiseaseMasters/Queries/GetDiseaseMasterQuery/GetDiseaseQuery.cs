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

namespace SRIS.Application.DiseaseMasters.Queries.GetDiseaseMasterQuery
{
   public class GetDiseaseQuery: IRequest<DiseaseMasterVM>
    {
        public int diseaseid { get; set; }
    }
    public class GetDiseaseQueryHandler : IRequestHandler<GetDiseaseQuery, DiseaseMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDiseaseQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DiseaseMasterVM> Handle(GetDiseaseQuery request, CancellationToken cancellationToken)
        {
            return new DiseaseMasterVM
            {
                Lists = await _context.m_master_disease
                    .ProjectTo<DiseaseMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.diseasename)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}

