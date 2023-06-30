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

namespace SRIS.Application.ContactTypeMaster.Queries.GetContactType
{
  public  class GetContactTypeQuery : IRequest<ContactTypeVM>
    {
        public int id { get; set; }
    }
    public class GetContactTypeQueryHandler : IRequestHandler<GetContactTypeQuery, ContactTypeVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetContactTypeQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ContactTypeVM> Handle(GetContactTypeQuery request, CancellationToken cancellationToken)
        {
            return new ContactTypeVM
            {
                Lists = await _context.m_master_Contacttype
                    .ProjectTo<ContactTypeDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.Designation)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
