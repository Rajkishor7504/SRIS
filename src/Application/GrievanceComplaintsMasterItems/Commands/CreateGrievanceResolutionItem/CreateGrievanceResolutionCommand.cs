using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.GrievanceComplaintsMasterItems.Commands.CreateGrievanceResolutionItem
{
    public class CreateGrievanceResolutionCommand : IRequest<string>
    {
        [Key]
        public int registrationid { get; set; }
        public string name { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
        public string community { get; set; }
        public string contactno { get; set; }
        public string Email { get; set; }
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
        public int Id { get; set; }

    }
    public class CreateGrievanceResolutionCommandHandler : IRequestHandler<CreateGrievanceResolutionCommand, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _datetime;


        public CreateGrievanceResolutionCommandHandler(IApplicationDbContext context, IDateTime datetime)
        {
            _context = context;
            _datetime = datetime;

        }

        public async Task<string> Handle(CreateGrievanceResolutionCommand request, CancellationToken cancellationToken)
        {

            string retval = "";
            var entity = new GrievanceComplaints();
            var entity1 = new NotificationMasterTable();
            int count = 0;

            try
            {
                count = _context.t_grievance_registration.Where(x => x.registrationid == request.registrationid && x.name == request.name).Count();

                if (count == 0)
                {
                    if (request.document != null)
                    {
                        var supportedTypes = new[] { "pdf", "docx", "jpeg", "jpg", "gif", "tiff", "png" };
                        var fileExt = System.IO.Path.GetExtension(request.document).Substring(1);
                        if (!supportedTypes.Contains(fileExt))
                        {
                            retval = "3";
                        }
                    }
                    if (retval != "3")
                    {
                        entity.name = request.name;
                        entity.regionid = request.regionid;
                        entity.districtid = request.districtid;
                        entity.wardid = request.wardid;
                        entity.settlementid = request.settlementid;
                        entity.community = request.community;
                        entity.contactno = request.contactno;
                        entity.Email = request.Email;
                        entity.dateofreceiptofthegrievance = request.dateofreceiptofthegrievance;
                        entity.timeofreceiptofthegrievance = request.dateofreceiptofthegrievance.ToString("hh:mm tt");
                        entity.admissibility = request.admissibility;
                        entity.relationshiptotheproject = request.relationshiptotheproject;
                        entity.grievanceconfigid = request.grievanceconfigid;
                        entity.status = request.status;
                        entity.ticketid = request.ticketid;
                        entity.grievancedescription = request.grievancedescription;
                        entity.association = request.association;
                        entity.document = request.document == null ? "null" : entity.ticketid + "." + request.document.Split('.')[1];
                        entity.createdby = -1;
                        entity.createdon = _datetime.Now;
                        entity.deletedflag = false;
                        entity.isportal = false;
                        entity.registrationid = request.registrationid;
                        _context.t_grievance_registration.Add(entity);
                        await _context.SaveChangesAsync(cancellationToken);
                        retval = entity.ticketid;

                        if (retval != null || retval != "")
                        {
                            var refNo = _context.t_grievance_registration.OrderByDescending(p => p.registrationid).FirstOrDefault().registrationid;
                            entity1.NotificationStatus = Convert.ToInt32(request.status);
                            entity1.refNo = Convert.ToInt32(refNo);
                            entity1.Information = "The Complain No:" + retval + " is pending for approval";
                            entity1.DestinationURL = "/Grievance/GrievanceResolutionMaster/PendingGrievance";
                            entity1.ModuleName = "Grievance Registration27";
                            entity1.CreatedBy = entity.createdby;
                            entity1.CreatedDate = _datetime.Now;
                            entity1.UpdatedBy = entity.createdby;
                            entity1.UpdatedDate = _datetime.Now;
                            entity1.Id = request.Id;
                            _context.t_all_notification.Add(entity1);
                            await _context.SaveChangesAsync(cancellationToken);


                        }

                    }
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
