using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.NotificationMasterItem.Queries.GetNotoficationMasterQueriesItem;
using SRIS.Domain.Entities.Grievance;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.GrievanceComplaintsMasterItems.Commands.UpdateGrievanceRegistration
{
    public class UpdateGrievanceCommand : IRequest<int>
    {
        public int registrationid { get; set; }
        public string name { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
        public string community { get; set; }
        public string contactno { get; set; }
        public DateTime dateofreceiptofthegrievance { get; set; }
        public string timeofreceiptofthegrievance { get; set; }
        public int admissibility { get; set; }
        public string relationshiptotheproject { get; set; }
        public int grievanceconfigid { get; set; }
        public ResolutionStatus status { get; set; }
        public string ticketid { get; set; }
        public string grievancedescription { get; set; }
        public string association { get; set; }
        public string document { get; set; }
        public int createdby { get; set; }
        public string action { get; set; }
        public string remarks { get; set; }
        public string purpose { get; set; }
        public string grievancedocument { get; set; }
        public int refNo { get; set; }

    }
    public class UpdateGrievanceCommandHandler : IRequestHandler<UpdateGrievanceCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _datetime;
        private readonly IGrievanceService _igrievanceService;

        public UpdateGrievanceCommandHandler(IApplicationDbContext context, IDateTime datetime, IGrievanceService igrievanceService)
        {
            _context = context;
            _datetime = datetime;
            _igrievanceService = igrievanceService;
        }

        public async Task<int> Handle(UpdateGrievanceCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            Regex rgx1 = new Regex("[^A-Za-z0-9 ]");
            var entity1 = new NotificationMasterDto();
            int retval = 0;
            if (request.registrationid != 0)
            {
                if (request.action == "A" || request.action == "R" || request.action == "RO" || request.action == "I")
                {
                    var status = new GrievanceStatus();
                    var entity = await _context.t_grievance_registration.FindAsync(request.registrationid);
                    if (entity == null)
                    {
                        throw new NotFoundException(nameof(GrievanceComplaints), request.registrationid);
                    }
                    
                    var forward = _context.t_grievance_forward.Where(x => x.grievanceId == request.registrationid).OrderByDescending(x => x.forwardedId).FirstOrDefault();
                    if (forward != null && request.action != "I")
                    {
                        forward.remarks = request.remarks;
                        forward.updatedby = request.createdby;
                        forward.updatedon = _datetime.Now;
                        if (request.action == "A")
                            forward.status = ForwardStatus.Resolved;
                        else if (request.action == "R")
                            forward.status = ForwardStatus.Rejected;
                        else if (request.action == "RO")
                            forward.status = ForwardStatus.Pending;
                    }
                    if (request.action == "A")
                    {
                        entity.status = ResolutionStatus.Resolved;
                    }
                    else if (request.action == "R")
                    {
                        entity.status = ResolutionStatus.Rejected;
                    }
                    //else if (request.action == "I")
                    //{
                    //    entity.status = ResolutionStatus.Inprogress;
                    //}
                    entity.actiondate = DateTime.Now;
                    entity.updatedby = request.createdby;
                    entity.updatedon = _datetime.Now;
                    entity.registrationid = request.registrationid;
                    entity.admissibility = request.admissibility;
                    entity.relationshiptotheproject = request.relationshiptotheproject;
                   // entity.remarks = request.remarks;
                    entity.grievanceconfigid = request.grievanceconfigid;
                    entity.association = request.association;


                    //---------- Start Grievance Status Add--------------------
                    status.grievanceId = request.registrationid;                    
                    if (request.action == "A")
                        status.status = ResolutionStatus.Resolved;
                    else if (request.action == "R")
                        status.status = ResolutionStatus.Rejected;
                    else if (request.action == "RO")
                        status.status = ResolutionStatus.Pending;
                    else if (request.action == "I")
                        status.status = ResolutionStatus.Inprogress;
                    status.remarks = request.remarks;
                    status.purpose = request.purpose;
                    
                    status.createdby = request.createdby;
                    status.createdon = DateTime.Now;
                    _context.t_grievance_status.Add(status);
                    //---------- End Grievance Status Add--------------------
                    try
                    {
                        await _context.SaveChangesAsync(cancellationToken);
                        if (!string.IsNullOrEmpty(request.grievancedocument))
                        {
                            var statusentity = await _context.t_grievance_status.FindAsync(status.statusid);
                            statusentity.grievancedocument = status.statusid + "." + request.grievancedocument.Split('.')[1];
                            await _context.SaveChangesAsync(cancellationToken);
                        }
                    }
                    catch (Exception ex) { }
                    retval = status.statusid;
                    if (retval != 0)
                    {
                        entity1.refNo = request.registrationid;
                        entity1.ModuleName = "Grievance Registration";
                        await _igrievanceService.UpdateGrievanceNotification(entity1);
                    }
                }
                else
                {
                    var entity = await _context.t_grievance_registration.FindAsync(request.registrationid);
                    try
                    {
                        if (entity == null)
                        {
                            throw new NotFoundException(nameof(GrievanceComplaints), request.registrationid);
                        }

                        entity.name = request.name;
                        entity.grievanceconfigid = request.grievanceconfigid;
                        entity.regionid = request.regionid;
                        entity.districtid = request.districtid;
                        entity.wardid = request.wardid;
                        entity.settlementid = request.settlementid;
                        entity.community = request.community;
                        entity.contactno = request.contactno;
                        entity.dateofreceiptofthegrievance = request.dateofreceiptofthegrievance;
                        entity.timeofreceiptofthegrievance = request.timeofreceiptofthegrievance;
                        entity.admissibility = request.admissibility;
                        entity.relationshiptotheproject = request.relationshiptotheproject;
                        entity.grievanceconfigid = request.grievanceconfigid;
                        entity.grievancedescription = request.grievancedescription;
                        entity.association = request.association;
                        entity.actiondate = DateTime.Now;
                        entity.updatedby = request.createdby;
                        entity.updatedon = _datetime.Now;
                        entity.registrationid = request.registrationid;
                        bool hasSpecialChars = rgx.IsMatch(entity.name);
                        bool hasSpecialChars1 = rgx.IsMatch(entity.association);
                        bool hasSpecialChars2 = rgx.IsMatch(entity.community);
                        bool hasSpecialChars3 = rgx1.IsMatch(entity.grievancedescription);

                        if (hasSpecialChars == false && hasSpecialChars1 == false && hasSpecialChars2 == false && hasSpecialChars3 == false)
                        {
                            await _context.SaveChangesAsync(cancellationToken);
                            retval = 2;
                        }
                        else
                        {
                            retval = 403;
                        }
                    }
                    catch (System.Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return retval;
        }
    }
}
