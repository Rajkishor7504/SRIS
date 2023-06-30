using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.GrievanceComplaintsMasterItems.Commands.CreateGrievanceRegistration
{
    public class CreateGrievanceCommand : IRequest<string>
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
        public int Id { get; set; }
        public int roleid { get; set; }

    }
    public class CreateGrievanceCommandHandler : IRequestHandler<CreateGrievanceCommand, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _datetime;

        public CreateGrievanceCommandHandler(IApplicationDbContext context, IDateTime datetime)
        {
            _context = context;
            _datetime = datetime;
        }
        public async Task<string> Handle(CreateGrievanceCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            Regex rgx1 = new Regex("[^A-Za-z0-9 ]");
            var entity1 = new NotificationMasterTable();
            Random rnd = new Random();
            var entity = new GrievanceComplaints();            
            int count = 0;
            string retval = "";
           
            try
            {
                count = _context.t_grievance_registration.Where(x => x.registrationid == request.registrationid && x.name == request.name).Count();
                var query = _context.t_grievance_registration.Count(s => s.dateofreceiptofthegrievance.Month == DateTime.Today.Month && s.dateofreceiptofthegrievance.Year == DateTime.Today.Year && s.deletedflag==false);
                var x = "C" + Convert.ToBase64String(BitConverter.GetBytes(DateTime.Now.Ticks + rnd.Next(query))).Trim('=').ToUpper();
                entity.ticketid = x.Trim('G', 'G');
                if (query == 0)
                {
                    entity.ticketid = "C" + DateTime.Now.ToString("MMyy") + "000" + 1;
                }
                else
                {
                    var cnt = ++query;
                    entity.ticketid = "C" + DateTime.Now.ToString("MMyy") + cnt.ToString().PadLeft(4, '0');
                }
                if (count == 0)
                {
                    if (request.registrationid == 0)
                    {
                        entity.name = request.name;
                        entity.regionid = request.regionid;
                        entity.districtid = request.districtid;
                        entity.wardid = request.wardid;
                        entity.settlementid = request.settlementid;
                        entity.community = request.community;
                        entity.contactno = request.contactno;
                        entity.dateofreceiptofthegrievance = request.dateofreceiptofthegrievance;
                        entity.timeofreceiptofthegrievance = request.dateofreceiptofthegrievance.ToString("hh:mm tt");
                        entity.admissibility = request.admissibility;
                        entity.relationshiptotheproject = request.relationshiptotheproject;
                        entity.grievanceconfigid = request.grievanceconfigid;
                        entity.status = request.status;
                        //entity.ticketid = request.ticketid;
                        entity.grievancedescription = request.grievancedescription;
                        entity.association = request.association;
                        entity.document = request.document == null ? "null" : entity.ticketid + "." + request.document.Split('.')[1];
                        entity.createdby = request.createdby;
                        entity.createdon = _datetime.Now;
                        entity.deletedflag = false;
                        entity.isportal = true;
                        entity.registrationid = request.registrationid;

                        bool hasSpecialChars = rgx.IsMatch(entity.name);
                        bool hasSpecialChars1 = rgx.IsMatch(entity.association);
                        bool hasSpecialChars2 = rgx.IsMatch(entity.community);
                        bool hasSpecialChars3 = rgx1.IsMatch(entity.grievancedescription);

                    if (hasSpecialChars == false && hasSpecialChars1 == false && hasSpecialChars2 == false && hasSpecialChars3 == false)
                    {
                        _context.t_grievance_registration.Add(entity);
                        await _context.SaveChangesAsync(cancellationToken);
                        retval = entity.ticketid;
                    
                        if (retval != null || retval != "")
                        {
                            var refNo = _context.t_grievance_registration.OrderByDescending(p => p.registrationid).FirstOrDefault().registrationid;
                            entity1.NotificationStatus = Convert.ToInt32(request.status);
                            entity1.refNo = Convert.ToInt32(refNo);
                            entity1.Information = "The Complain No:" + retval + " is pending for approval";
                            entity1.DestinationURL = "/Grievance/GrievanceRegistration/Index";
                            entity1.ModuleName = "Grievance Registration" + request.roleid;
                            entity1.CreatedBy = entity.createdby;
                            entity1.CreatedDate = _datetime.Now;
                            entity1.UpdatedBy = entity.createdby;
                            entity1.UpdatedDate = _datetime.Now;
                            entity1.Id = request.Id;
                            _context.t_all_notification.Add(entity1);
                            await _context.SaveChangesAsync(cancellationToken);


                        }
                    }
                    else
                    {
                        retval = "403";
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
