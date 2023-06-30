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

namespace SRIS.Application.PurposeMaster.Queries.GetPurposeMaster
{
   public class GetPurposeMasterQuery:IRequest<PurposeMasterVM>
    {
        public int purposeid { get; set; }
    }
    public class GetPurposeMasterQueryQueryhandler : IRequestHandler<GetPurposeMasterQuery, PurposeMasterVM>
    {
        private readonly IApplicationDbContext _Context;
        private readonly IMapper _mapper;
        public GetPurposeMasterQueryQueryhandler(IApplicationDbContext context,IMapper mapper)
        {
            _Context = context;
            _mapper = mapper;
        }
        public async Task<PurposeMasterVM> Handle(GetPurposeMasterQuery Request, CancellationToken cancellationToken)
        {
            return new PurposeMasterVM
            {
                Lists = await _Context.m_master_purpose.ProjectTo<PurposeMasterDto>(_mapper.ConfigurationProvider).Where(t => t.deletedflag == false).OrderBy(t => t.purposename)
                    .ToListAsync(cancellationToken)
            };
        }
    }

}
