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

namespace SRIS.Application.ToiletTypeMasters.Queries.GetToiletTypeMaster
{
  public  class GetToiletTypeMasterQuery : IRequest<ToiletTypeMasterVM>
    {
        public int typeid { get; set; }
    }
    public class GetCookingFuelMasterQueryHandler : IRequestHandler<GetToiletTypeMasterQuery, ToiletTypeMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCookingFuelMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ToiletTypeMasterVM> Handle(GetToiletTypeMasterQuery request, CancellationToken cancellationToken)
        {
            return new ToiletTypeMasterVM
            {
                Lists = await _context.m_master_toilettype
                    .ProjectTo<ToiletTypeMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.typename)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}