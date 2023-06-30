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

namespace SRIS.Application.DeviceManagementMaster.Queries.GetDeviceManagementMaster
{
    public class GetDeviceMngtMasterQuery : IRequest<DeviceMngtMasterVM>
    {
        public int deviceconfigid { get; set; }
        public string make { get; set; }
        public string IMEI { get; set; }
    }
    public class GetDeviceMngtMasterQueryHandler : IRequestHandler<GetDeviceMngtMasterQuery, DeviceMngtMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDeviceMngtMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DeviceMngtMasterVM> Handle(GetDeviceMngtMasterQuery request, CancellationToken cancellationToken)
        {
            if ((request.make == null || request.make == "") && (request.IMEI == null || request.IMEI == ""))
            {
                return new DeviceMngtMasterVM
                {
                    Lists = await _context.m_master_deviceconfig
                   .ProjectTo<DeviceMngtMasterDto>(_mapper.ConfigurationProvider)
                   .OrderBy(t => t.make)
                   .Where(s=>s.deletedflag==false)
                   .ToListAsync(cancellationToken)
                };
            }
            else
            {
                return new DeviceMngtMasterVM
                {
                    Lists = await _context.m_master_deviceconfig
                   .ProjectTo<DeviceMngtMasterDto>(_mapper.ConfigurationProvider).Where(x => x.make == request.make || x.deviceimeinumber == request.IMEI)
                   .OrderBy(t => t.make)
                    .Where(s => s.deletedflag == false)
                   .ToListAsync(cancellationToken)
                };
            }


        }
    }
}

