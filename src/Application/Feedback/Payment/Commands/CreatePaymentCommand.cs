using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Feedback.Payment.Queries;
using SRIS.Application.NotificationMasterItem.Queries.GetNotoficationMasterQueriesItem;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Feedback.Payment.Commands
{
    public class CreatePaymentCommand : IRequest<int>
    {
        public List<PaymentDto> Lists { get; set; }
        public string action { get; set; }
        public int createdby { get; set; }
        public string programname { get; set; }
        public string programcode { get; set; }
        public int programid { get; set; }
        public string filename { get; set; }
        public int programdetailsid { get; set; }
        public string remark { get; set; }
        public bool deletedflag { get; set; }
        public int paymentid { get; set; }

    }
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, int>
    {
        private readonly IPaymentService _iPaymentService;
        private readonly IApplicationDbContext _context;

        public CreatePaymentCommandHandler(IPaymentService iPaymentService, IApplicationDbContext context)
        {
            _iPaymentService = iPaymentService;
            _context = context;
        }

        public async Task<int> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            Regex rgx1 = new Regex("[^A-Za-z0-9 ]");

            int retval = 0;
            var entity = new Paymentprogramdtls();
            //var entity = new PaymentDto();
            //entity.action = request.action;
            //entity.createdby = request.createdby;
            //entity.Lists = request.Lists;
            //entity.programname = request.programname;
            //entity.programcode = request.programcode;
            //entity.programid = request.programid;
            //entity.filename = request.filename;
            //entity.programdetailsid = request.programdetailsid;
            //entity.remark = request.remark;
            ////retval = await _iPaymentService.AddPayment(entity);
            //return retval;
            if (request.Lists.Count > 0)
            {

                var createdon = DateTime.Now;
               
                entity.createdby = request.createdby;
                entity.createdon = createdon;
                entity.programname = request.programname;
                entity.programcode = request.programcode;
                entity.programid = request.programid;
                entity.filename = request.filename;
                entity.documentType = 1;
                var program = _context.t_feedback_paymentprogramdtls.OrderByDescending(p => p.programdetailsid).FirstOrDefault();
                entity.programdetailsid = program == null ? 0 : program.programdetailsid + 1;
                entity.remark = request.remark;

               
            var entityPayment = new List<PaymentDetail>();

            request.Lists.ForEach(pd => entityPayment.Add(new PaymentDetail()

            {
                householdnumber = pd.householdnumber,
                location = pd.location,
                district = pd.District,
                ward = pd.Ward,
                settlement = pd.Settlement,
                programmcode = pd.programcode,
                programmname = pd.programname,
                sector = pd.Sector,
                membercode = pd.membercode,
                benificiaryname = pd.benificiaryname,
                enrollmentstartdate = pd.dateofcashtransefer,
                enrollmentenddate = pd.datesofactualtransefer,
                enrollmentStatus = pd.EnrollmentStatus,
                benefits = pd.Benefits,
                amount = pd.amounttodate,
                transferfreq = pd.TransferFreq,
                createdby = request.createdby,
                createdon = DateTime.Now,
                programdetailsid = entity.programdetailsid==0?1:entity.programdetailsid,
                hhid = _context.t_hhr_registerhousehold.FirstOrDefault(a => a.hhcode == pd.householdnumber).hhid,
                paymenttype = "NA",
                amounttodate = 0,
                amountinlastcycle = 0,
                dateofcashtransefer = DateTime.Now,
                datesofactualtransefer = DateTime.Now,
                proxyrecipientname = "NA",
                dobofproxy = DateTime.Now,
                genderofproxy = "NA",
                relationofproxytorecipient = "NA",
                paymentserviceprovider = "NA",
                documenttype = 1
            }));
            try
              {
               bool hasSpecialChars1 = rgx1.IsMatch(entity.remark);
                    if (hasSpecialChars1 == false)
                    {
                        _context.t_feedback_paymentprogramdtls.Add(entity);
                        await _context.SaveChangesAsync(cancellationToken);

           
                       _context.t_feedback_paymentdetail.AddRange(entityPayment);
            
                       await _context.SaveChangesAsync(cancellationToken);
                       retval= 200;
                        if (retval == 200)
                        {
                            NotificationMasterDto entity1 = new NotificationMasterDto();
                            entity1.NotificationStatus = 0;
                            entity1.Information = "Payment Request Pending At NSPS For Approval";
                            entity1.DestinationURL = "/Feedback/PaymentDeatails/ViewPendingPayment";
                            entity1.CreatedBy = request.createdby;
                            await _iPaymentService.AddPaymentNotification(entity1);
                        }
                    }
                    else
                    {
                        retval = 403;
                    }
                }
            catch (Exception ex)
            {
                    throw ex;
            }
            }

            return retval;
           
        }
        
        
    }
    
}


