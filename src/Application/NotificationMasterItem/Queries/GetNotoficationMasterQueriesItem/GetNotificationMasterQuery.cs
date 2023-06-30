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

namespace SRIS.Application.NotificationMasterItem.Queries.GetNotoficationMasterQueriesItem
{
    public  class GetNotificationMasterQuery: IRequest<NotificationMasterVM>
    {
        public int Id { get; set; }
        public int NotificationStatus { get; set; }
        public string Information { get; set; }
        public int refNo { get; set; }
        public string DestinationURL { get; set; }
        public string ModuleName { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string action { get; set; }
    }
    public class GetNotificationMasterQueryHandler : IRequestHandler<GetNotificationMasterQuery, NotificationMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IGrievanceService _igrievanceService;

        public GetNotificationMasterQueryHandler(IApplicationDbContext context, IMapper mapper, IGrievanceService igrievanceService)
        {
            _context = context;
            _mapper = mapper;
            _igrievanceService = igrievanceService;
        }
        public async Task<NotificationMasterVM> Handle(GetNotificationMasterQuery request, CancellationToken cancellationToken)
        {
            var entity = new NotificationMasterDto();
            entity.refNo = request.refNo;
            //entity.action = request.action;
            if (request.action != null)
            {
                entity.action = request.action;
                entity.CreatedBy = request.CreatedBy;
                return new NotificationMasterVM
                {
                    Lists = await _igrievanceService.GetNotificationCount(entity)
                };
            }
            return new NotificationMasterVM
            {
                Lists = await _igrievanceService.GetNotificationDetails(entity)
            };
        }
    }
}
