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

namespace SRIS.Application.Users.Queries.GetUsers
{
   public class GetUsersQuery : IRequest<UsersVM>
    {
    }
    public class GetUserQueryHandler : IRequestHandler<GetUsersQuery, UsersVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UsersVM> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return new UsersVM
            {
                Lists = await _context.m_um_user
                    .ProjectTo<UsersDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.username)
                    .ToListAsync(cancellationToken)
            };
        }
    }

}
