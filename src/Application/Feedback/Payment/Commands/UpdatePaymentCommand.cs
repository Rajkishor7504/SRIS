using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Feedback.Payment.Queries;
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
   public class UpdatePaymentCommand : IRequest<int>
    {
        public int programdetailsid { get; set; }
        public int updatedby { get; set; }
        public string approvalremark { get; set; }
        public int status { get; set; }
        public bool deletedflag { get; set; }
        public IList<UpdateHouseholdDto> List { get; set; }
        public int paymentid { get; set; }
        public string useremail { get; set; }//added by deepak for select partner email
        public string programname { get; set; }//added by deepak for select programme name at the time of Approved/Rejected
    }
    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, int>
    {
        private readonly IPaymentService _iPaymentService;
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public UpdatePaymentCommandHandler(IPaymentService iPaymentService, IApplicationDbContext context,IDateTime dateTime)
        {
            _iPaymentService = iPaymentService;
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
            var ent = new PaymentDetail();
            var entity = _context.t_feedback_paymentprogramdtls.Where(a => a.programdetailsid == request.programdetailsid).SingleOrDefault();
            try
            {
                if (request.List != null)
                {


                    if (request.List.Count != 0 && request.List!=null && request.status==1)
                    {
                    foreach (var lst in request.List)
                    {

                        ent.householdnumber = lst.householdnumber;
                        ent.location = "NA";
                        ent.district = lst.district;
                        ent.ward = lst.ward;
                        ent.settlement = lst.settlement;
                        ent.programmcode = lst.programmcode;
                        ent.programmname = lst.programmname;
                        ent.sector = lst.sector;
                        ent.membercode = lst.memberid;
                        ent.benificiaryname = lst.benificiaryname;
                        ent.enrollmentstartdate = Convert.ToDateTime(lst.enrollmentstartdate);
                        ent.enrollmentenddate = Convert.ToDateTime(lst.enrollmentenddate);
                        ent.amount = lst.amount;
                        ent.transferfreq = lst.transferfreq;
                        ent.createdby =1;
                        ent.createdon = _dateTime.Now;
                        ent.programdetailsid =request.programdetailsid;
                        ent.paymenttype = "NA";
                        ent.amounttodate = 0;
                        ent.amountinlastcycle = 0;
                        ent.proxyrecipientname = "NA";
                        ent.genderofproxy = "NA";
                        ent.relationofproxytorecipient = "NA";
                        ent.paymentserviceprovider = "NA";
                        ent.documenttype = 2;
                        ent.paymentid = request.paymentid;
                        _context.t_feedback_paymentdetail.AddRange(ent);
                        await _context.SaveChangesAsync(cancellationToken);
                    }
                        entity.updatedby = request.updatedby;
                        entity.updatedon = DateTime.Now;
                        entity.deletedflag = request.deletedflag;
                        entity.programdetailsid = request.programdetailsid;
                        entity.status = request.status;
                        entity.approvalremarks = request.approvalremark;
                        _context.t_feedback_paymentprogramdtls.Update(entity);
                        await _context.SaveChangesAsync(cancellationToken);
                        retval = 200;
                        return retval;
                    }
                }
                else 
                 {
                    entity.updatedby = request.updatedby;
                    entity.updatedon = DateTime.Now;
                    entity.deletedflag = request.deletedflag;
                    entity.programdetailsid = request.programdetailsid;
                    entity.status = request.status;
                    entity.approvalremarks = request.approvalremark;
                    _context.t_feedback_paymentprogramdtls.Update(entity);
                    await _context.SaveChangesAsync(cancellationToken);
                    retval = 200;
                    if (retval == 200)
                    {
                        NotificationMasterDto entity1 = new NotificationMasterDto();
                        entity1.NotificationStatus = 1;
                        entity1.CreatedBy = request.updatedby;
                        entity1.refNo = request.programdetailsid;
                        await _iPaymentService.UpdatePaymentNotification(entity1);
                    }
                }
                retval = 200;
                return retval;
            }
            catch (Exception ex)
            {
                //return 0;
                throw new Exception(ex.Message);
            }
        }

    }
}
