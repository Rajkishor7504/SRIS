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

namespace SRIS.Application.DoyouhaveBirthCertificateMasters.Queries.GetDoYouhavebirthCertificateItemsQuery
{
    public class GetDoYouhavebirthcertificateQueries : IRequest<DoYouhavebirthCertificateItemsVM>
    {
        public int id { get; set; }
    }
    public class GetDoYouhavebirthcertificateQueriesHandler : IRequestHandler<GetDoYouhavebirthcertificateQueries, DoYouhavebirthCertificateItemsVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDoYouhavebirthcertificateQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DoYouhavebirthCertificateItemsVM> Handle(GetDoYouhavebirthcertificateQueries request, CancellationToken cancellationToken)
        {
            return new DoYouhavebirthCertificateItemsVM
            {
                Lists = await _context.m_master_doyouhavebirthcertificate
                    .ProjectTo<DoYouhavebirthCertificateItemsDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.doyouhavebirthcertificate)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
