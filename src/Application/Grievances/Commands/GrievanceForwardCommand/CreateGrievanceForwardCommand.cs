/*
* File Name : CreateRegisterMemberCommand.cs
* class Name : CreateRegisterMemberCommand, CreateRegisterMemberCommandHandler
* Created Date : 26 Aug 2021
* Created By : Spandana Ray
* Description : command class to forward the grievance to next level
*/
using MediatR;
using SRIS.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SRIS.Domain.Entities.Grievance;
using SRIS.Domain.Entities.MasterEntities;
using System;
using SRIS.Application.NotificationMasterItem.Queries.GetNotoficationMasterQueriesItem;

namespace SRIS.Application.Grievances.Commands.GrievanceForwardCommand
{
    public class CreateGrievanceForwardCommand : IRequest<int>
    {
        public int forwardedId { get; set; }
        public int grievanceId { get; set; }
        public int forwardedBy_userId { get; set; }
        public int forwardedBy_committeeId { get; set; }
        public int forwardedTo_committeeId { get; set; }
        public ForwardStatus status { get; set; }
        public string remarks { get; set; }
        public int admissibility { get; set; }
        public string relationshiptotheproject { get; set; }
        public int grievanceconfigid { get; set; }
        public string association { get; set; }
        public int roleid { get; set; }
    }
    public class CreateGrievanceForwardCommandHandler : IRequestHandler<CreateGrievanceForwardCommand, int>
    {
        private readonly IApplicationDbContext _context; 
        private readonly IGrievanceService _igrievanceService;
        public CreateGrievanceForwardCommandHandler(IApplicationDbContext context, IGrievanceService igrievanceService)
        {
            _context = context;
            _igrievanceService = igrievanceService;
        }
        public async Task<int> Handle(CreateGrievanceForwardCommand request, CancellationToken cancellationToken)
        {
            var entity1 = new NotificationMasterDto();
            var entity = new GrievanceForward();
            var status = new GrievanceStatus();
            int retval = 0;
            try
            {
                _context.t_grievance_forward.Where(x => x.grievanceId == request.grievanceId).ToList().ForEach(c => c.status = ForwardStatus.Forwarded);
                entity.grievanceId = request.grievanceId;
                entity.forwardedBy_userId = request.forwardedBy_userId;
                entity.forwardedBy_committeeId = request.forwardedBy_committeeId;
                entity.forwardedTo_committeeId = request.forwardedTo_committeeId;
                entity.createdby = request.forwardedBy_userId;
                entity.createdon = DateTime.Now;
                entity.status = ForwardStatus.Pending;
                entity.remarks = request.remarks;
                _context.t_grievance_forward.Add(entity);

                //---------- Start Grievance Status Add--------------------
                status.grievanceId = request.grievanceId;
                status.status = ResolutionStatus.Forwarded;
                status.remarks = request.remarks;
                status.createdby = request.forwardedBy_userId;
                status.createdon = DateTime.Now;
                _context.t_grievance_status.Add(status);
                //---------- End Grievance Status Add--------------------
              
                var grievanceEntity = _context.t_grievance_registration.FirstOrDefault(g => g.registrationid == request.grievanceId);
                grievanceEntity.status = ResolutionStatus.Forwarded;
                grievanceEntity.admissibility = request.admissibility;
                grievanceEntity.relationshiptotheproject = request.relationshiptotheproject;
                grievanceEntity.grievanceconfigid = request.grievanceconfigid;
                grievanceEntity.association = request.association;
                await _context.SaveChangesAsync(cancellationToken);
                retval = 1;
                if (retval == 1)
                {
                    entity1.refNo = request.grievanceId;
                    entity1.ModuleName = "Grievance Registration" + request.roleid;
                    await _igrievanceService.UpdateGrievanceNotification(entity1);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return retval;
        }
    }
}
