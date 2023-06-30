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

namespace SRIS.Application.ResortFoodCopingMasters.Queries.GetResortFoodCopingMasterItem
{
    public class GetResortFoodCopingQuery:IRequest<ResortFoodCopingVM>
    {
        public int resortfoodcopingid { get; set; }
    }
public class GetResortFoodCopingQueryHandler : IRequestHandler<GetResortFoodCopingQuery, ResortFoodCopingVM>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetResortFoodCopingQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ResortFoodCopingVM> Handle(GetResortFoodCopingQuery request, CancellationToken cancellationToken)
    {
        return new ResortFoodCopingVM
        {
            Lists = await _context.m_master_resortfoodCoping
                .ProjectTo<ResortFoodCopingDto>(_mapper.ConfigurationProvider)
                .Where(t => t.deletedflag == false)
                .OrderBy(t => t.resortfoodcoping)
                .ToListAsync(cancellationToken)
        };
    }

}
}
