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

namespace SRIS.Application.WorkingSectors.Queries.GetWorkingSectorMaster
{
    public class GetWorkingSectorQuery: IRequest<WorkingSectorVM>
    {
        public int sectorid { get; set; }
    }
    public class GetWorkingSectorQueryHandler : IRequestHandler<GetWorkingSectorQuery, WorkingSectorVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetWorkingSectorQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WorkingSectorVM> Handle(GetWorkingSectorQuery request, CancellationToken cancellationToken)
        {
            return new WorkingSectorVM
            {
                Lists = await _context.m_master_workingsector
                    .ProjectTo<WorkingSectorDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.sectorname)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}


