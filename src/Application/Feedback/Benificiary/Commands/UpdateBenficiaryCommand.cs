using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.NotificationMasterItem.Queries.GetNotoficationMasterQueriesItem;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Feedback.Payment.Commands
{
   public class UpdateBenficiaryCommand : IRequest<int>
    {
        public int programdetailsid { get; set; }
        public int updatedby { get; set; }
        public string approvalremark { get; set; }
        public int status { get; set; }
        public bool deletedflag { get; set; }
        public string useremail { get; set; }//added by deepak for select partner email
        public string programname { get; set; }//added by deepak for select programme name at the time of Approved/Rejected
    }
    public class UpdateBenficiaryCommandHandler : IRequestHandler<UpdateBenficiaryCommand, int>
    {
        private readonly IPaymentService _iPaymentService;
        private readonly IApplicationDbContext _context;
        private readonly IFeedbackService _iFeedbackService;
        public UpdateBenficiaryCommandHandler(IPaymentService iPaymentService, IApplicationDbContext context, IFeedbackService iFeedbackService)
        {
            _iPaymentService = iPaymentService;
            _context = context;
            _iFeedbackService = iFeedbackService;
        }

        public async Task<int> Handle(UpdateBenficiaryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                int retval = 0;
                var entity = _context.t_feedback_programdtls.Where(a => a.programdetailsid == request.programdetailsid).SingleOrDefault();
                if (entity != null)
                {
                    entity.updatedby = request.updatedby;
                    entity.updatedon = DateTime.Now;
                    entity.deletedflag = request.deletedflag;
                    entity.programdetailsid = request.programdetailsid;
                    entity.status = request.status;
                    entity.approvalremarks = request.approvalremark;
                    _context.t_feedback_programdtls.Update(entity);
                    await _context.SaveChangesAsync(cancellationToken);
                    retval = 200;
                    if (retval == 200)
                    {
                        NotificationMasterDto entity1 = new NotificationMasterDto();
                        entity1.NotificationStatus = 1;
                        entity1.CreatedBy = request.updatedby;
                        entity1.refNo = request.programdetailsid;
                        await _iFeedbackService.UpdateBeneficiaryNotification(entity1);
                    }
                }

                retval = 200;
                return retval;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return 0;
            }
        }

    }
}
