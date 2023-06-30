using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Applicatio.GrievanceComplaintsMasterItems.Commands.UpdateGrievanceResolutionItem
{
    public class UpdateGrievanceResolutionCommand : IRequest<int>
    {
        [Key]
        public int registrationid { get; set; }
        public string name { get; set; }
        public int grievanceconfigid { get; set; }
        public ResolutionStatus status { get; set; }
        public int createdby { get; set; }

    }
    public class UpdateGrievanceResolutionCommandHandler : IRequestHandler<UpdateGrievanceResolutionCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _datetime;

        public UpdateGrievanceResolutionCommandHandler(IApplicationDbContext context, IDateTime datetime)
        {
            _context = context;
            _datetime = datetime;
        }

        public async Task<int> Handle(UpdateGrievanceResolutionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.t_grievance_registration.FindAsync(request.registrationid);
            int id = _context.t_all_notification.Where(x => x.refNo == request.registrationid).FirstOrDefault().Id;
            var entity1 = await _context.t_all_notification.FindAsync(id);
            // int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(GrievanceComplaints), request.registrationid);
                }
                if (request.registrationid != 0)
                {
                    entity.name = request.name;
                    entity.grievanceconfigid = request.grievanceconfigid;
                    entity.status = request.status;
                    entity.actiondate = DateTime.Now;
                    entity.updatedby = request.createdby;
                    entity.updatedon = _datetime.Now;
                    entity.deletedflag = false;
                    entity.registrationid = request.registrationid;
                    await _context.SaveChangesAsync(cancellationToken);
                    retval = 2;
                    if (retval == 2 && id != 0)
                    {
                        entity1.NotificationStatus = 1;
                        entity1.Id = id;
                        entity1.UpdatedDate = _datetime.Now;
                        await _context.SaveChangesAsync(cancellationToken);


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

