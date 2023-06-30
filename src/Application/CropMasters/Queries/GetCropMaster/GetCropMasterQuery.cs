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

namespace SRIS.Application.CropMasters.Queries.GetCropMaster
{
    public class GetCropMasterQuery : IRequest<CropMasterVM>
    {
        public int cropid { get; set; }
    }
    public class GetCropMasterQueryHandler : IRequestHandler<GetCropMasterQuery, CropMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCropMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CropMasterVM> Handle(GetCropMasterQuery request, CancellationToken cancellationToken)
        {
            return new CropMasterVM
            {
                Lists = await _context.m_master_crop
                    .ProjectTo<CropMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.cropname)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
