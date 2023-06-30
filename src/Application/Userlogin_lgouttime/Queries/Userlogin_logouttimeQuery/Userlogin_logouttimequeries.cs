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

namespace SRIS.Application.Userlogin_lgouttime.Queries.Userlogin_logouttimeQuery
{
    public class Userlogin_logouttimequeries:IRequest<Userlogin_logouttimeVm>
    {
        public int id { get; set; }
    }
    public class Userlogin_logouttimequeriesHandler : IRequestHandler<Userlogin_logouttimequeries, Userlogin_logouttimeVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public Userlogin_logouttimequeriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Userlogin_logouttimeVm> Handle(Userlogin_logouttimequeries request, CancellationToken cancellationToken)
        {
            return new Userlogin_logouttimeVm
            {
                userlogin_logouttimeDto = await _context.m_user_login_logout_time
                    .ProjectTo<Userlogin_logouttimeDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.id)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}


