using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.GrievanceComplaintsMasterItems.Queries.GetGrievanceComplaintsItem
{
    public class GetGrievanceDetailQuery : IRequest<GrievanceResolutionMasterVM>
    {
        public int registrationid { get; set; }
        public string complainNo { get; set; }
    }
    public class GetGrievanceDetailQueryHandler : IRequestHandler<GetGrievanceDetailQuery, GrievanceResolutionMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IGrievanceService _igrivService;
        private readonly IMapper _mapper;
        public GetGrievanceDetailQueryHandler(IApplicationDbContext context, IGrievanceService igrivService, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _igrivService = igrivService;
        }
        public async Task<GrievanceResolutionMasterVM> Handle(GetGrievanceDetailQuery request, CancellationToken cancellationToken)
        {
            var grievanceVM = new GrievanceResolutionMasterVM();
            if (request.registrationid == 0)
            {
                var regId = _context.t_grievance_registration.FirstOrDefault(x => x.ticketid == request.complainNo && x.deletedflag ==false);
                if (regId == null)
                    return grievanceVM;
                request.registrationid = _context.t_grievance_registration.FirstOrDefault(x => x.ticketid == request.complainNo && x.deletedflag == false).registrationid;
            }
            var obj = from g in _context.t_grievance_registration.Where(x => x.registrationid == request.registrationid && x.deletedflag == false)
                     
                      join r in _context.m_adm_leveldetails on g.regionid equals r.leveldetailid
                      join d in _context.m_adm_leveldetails on g.districtid equals d.leveldetailid
                      join w in _context.m_adm_leveldetails on g.wardid equals w.leveldetailid
                      join s in _context.m_adm_leveldetails on g.settlementid equals s.leveldetailid
                      select new { grivresol = g, region = r, district = d, ward = w, settlement = s };
            grievanceVM.registrationid = obj.Select(s => s.grivresol.registrationid).FirstOrDefault();
            grievanceVM.ticketid = obj.Select(s => s.grivresol.ticketid).FirstOrDefault();
            grievanceVM.name = obj.Select(s => s.grivresol.name).FirstOrDefault();
            grievanceVM.dateofreceiptofthegrievance = obj.Select(s => s.grivresol.dateofreceiptofthegrievance).FirstOrDefault();
            grievanceVM.timeofreceiptofthegrievance = obj.Select(s => s.grivresol.timeofreceiptofthegrievance).FirstOrDefault();
            grievanceVM.community = obj.Select(s => s.grivresol.community).FirstOrDefault();
            grievanceVM.association = obj.Select(s => s.grivresol.association).FirstOrDefault();
            grievanceVM.relationshiptotheproject = obj.Select(s => s.grivresol.relationshiptotheproject).FirstOrDefault();
            grievanceVM.region = obj.Select(s => s.region.levelname).FirstOrDefault();
            grievanceVM.dist = obj.Select(s => s.district.levelname).FirstOrDefault();
            grievanceVM.ward = obj.Select(s => s.ward.levelname).FirstOrDefault();
            grievanceVM.settlement = obj.Select(s => s.settlement.levelname).FirstOrDefault();
            var gcId = obj.Select(s => s.grivresol.grievanceconfigid).FirstOrDefault();
            grievanceVM.grievancename = gcId == 0 ? "NA" : _context.m_grievance_configuregrievance.Where(gc => gc.grievanceconfigid == gcId).FirstOrDefault().grievancename;
            grievanceVM.grievancedescription = obj.Select(s => s.grivresol.grievancedescription).FirstOrDefault();
            grievanceVM.status = obj.Select(s => s.grivresol.status).FirstOrDefault();
            grievanceVM.GrievanceDetailLists = await _igrivService.GetGrievanceDetail(request.registrationid);
            grievanceVM.GrievanceDetailticketLists = await _igrivService.GetGrievanceticketdetailsDetail(request.registrationid);
            if (gcId == 4) { 
            grievanceVM.HouseholdDetailsLists = await _igrivService.GetHouseholddetails(request.registrationid);
            }
            grievanceVM.GrievanceStatusLists = await _igrivService.GetGrievanceStatusDetail(request.registrationid);
            return grievanceVM;
        }
    }
}
