using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.GrievanceComplaintsMasterItems.Queries.GetGrievanceComplaintsItem
{
    public class GetGrievanceResolutionMasterQuery : IRequest<GrievanceResolutionMasterVM>
    {
        public int registrationid { get; set; }
        public string action { get; set; }
        public string parentid { get; set; }
        //public int parentid { get; set; }
        public int userid { get; set; }
    }

    public class GetGrievanceResolutionMasterQueryHandler : IRequestHandler<GetGrievanceResolutionMasterQuery, GrievanceResolutionMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IGrievanceResolutionService _igrivService;

        public GetGrievanceResolutionMasterQueryHandler(IApplicationDbContext context, IMapper mapper, IGrievanceResolutionService igrivService)
        {
            _context = context;
            _mapper = mapper;
            _igrivService = igrivService;
        }
        public async Task<GrievanceResolutionMasterVM> Handle(GetGrievanceResolutionMasterQuery request, CancellationToken cancellationToken)
        {
            var entity = new GrievanceResolutionMasterDto();
            entity.action = request.action;
            entity.p_id = request.parentid;
            entity.userid = request.userid;

            if (request.registrationid == 0)
            {
                return new GrievanceResolutionMasterVM
                {
                    Lists = await _igrivService.Getgrievance(entity)

                };
            }
            else
            {
                var obj = from g in _context.t_grievance_registration.Where(x => x.registrationid == request.registrationid)
                              //join cg in _context.m_grievance_configuregrievance on g.grievanceconfigid equals cg.grievanceconfigid
                          join r in _context.m_adm_leveldetails on g.regionid equals r.leveldetailid
                          join d in _context.m_adm_leveldetails on g.districtid equals d.leveldetailid
                          join w in _context.m_adm_leveldetails on g.wardid equals w.leveldetailid
                          join s in _context.m_adm_leveldetails on g.settlementid equals s.leveldetailid
                          select new { grivresol = g, region = r, district = d, ward = w, settlement = s };

                var gcId = obj.Select(s => s.grivresol.grievanceconfigid).FirstOrDefault();
                return new GrievanceResolutionMasterVM
                {
                    Lists = await obj.Select(s => new GrievanceResolutionMasterDto
                    {
                        registrationid = s.grivresol.registrationid,
                        name = s.grivresol.name,
                        regionid = s.grivresol.regionid,
                        districtid = s.grivresol.districtid,
                        wardid = s.grivresol.wardid,
                        settlementid = s.grivresol.settlementid,
                        community = s.grivresol.community,
                        contactno = s.grivresol.contactno,
                        dateofreceiptofthegrievance = s.grivresol.dateofreceiptofthegrievance,
                        timeofreceiptofthegrievance = s.grivresol.timeofreceiptofthegrievance,
                        admis = s.grivresol.admissibility == 1 ? "Yes" : "No",
                        relationshiptotheproject = s.grivresol.relationshiptotheproject,
                        grievanceconfigid = s.grivresol.grievanceconfigid,
                        grievancename = gcId == 0 ? "NA" : _context.m_grievance_configuregrievance.Where(gc => gc.grievanceconfigid == gcId).FirstOrDefault().grievancename,
                        status = s.grivresol.status,
                        ticketid = s.grivresol.ticketid,
                        grievancedescription = s.grivresol.grievancedescription,
                        association = s.grivresol.association,
                        document = s.grivresol.document,
                        region = s.region.levelname,
                        dist = s.district.levelname,
                        ward = s.ward.levelname,
                        settlement = s.settlement.levelname,
                        createdby = s.grivresol.createdby.Value,
                        canForward = gcId == 0 ? true : _context.m_grievance_configuregrievance.Where(gc => gc.grievanceconfigid == gcId).FirstOrDefault().isForward,
                        isportal = s.grivresol.isportal
                    })
                    .ToListAsync(cancellationToken)
                };
            }
        }
    }
}
