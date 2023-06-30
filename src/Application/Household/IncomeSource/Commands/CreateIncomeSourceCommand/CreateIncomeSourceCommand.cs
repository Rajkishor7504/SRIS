using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Household.IncomeSource.Quries.GetIncomeSourceQuery;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.IncomeSource.Commands
{
    public class CreateIncomeSourceCommand: IRequest<IncomeSourceList>
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int incomesourceid { get; set; }
        public int mainincomesourceofhh { get; set; }
        public string otherincomesource { get; set; }
        public int secondincomesourceofhh { get; set; }
        public string othersecondincomesource { get; set; }
        public int didhhreceivemonetaryhelp { get; set; }
        public int howmanytimesreceivedmonhelp { get; set; }
        public int amountreceivedinlastoneyear { get; set; }
        public int hashhcollectedanyaidinoneyear { get; set; }
        public int freequencyofaidreceived { get; set; }
        public string otherfreequencyofaidreceived { get; set; }
        public string organizationtype { get; set; }
        public string aidids { get; set; }
        public string orgtypeids { get; set; }
        public string otheraid { get; set; }
        public string otherorgtype { get; set; }
        public int createdby { get; set; }
        public int apptypeid { get; set; }
        


    }
    public class CreateAssetInfoCommandHandler : IRequestHandler<CreateIncomeSourceCommand, IncomeSourceList>
    {


        private readonly IHouseholdService _iHouseholdService;

        public CreateAssetInfoCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<IncomeSourceList> Handle(CreateIncomeSourceCommand request, CancellationToken cancellationToken)
        {

            int retval = 0;
            IncomeSourceList objIncomeList = new IncomeSourceList();
          
            try
            {
                
                if ((request.hhid == 0 && request.action == "U"))
                {
                    objIncomeList.status = "400";
                    objIncomeList.message = CommonHelper.GetEnumDescription((ResponseStatus)400);
                }
                else
                {
                    var entity = new IncomeSourceDto();
                    entity.action = request.action;
                    entity.hhid = request.hhid;
                    entity.incomesourceid = request.incomesourceid;
                    entity.mainincomesourceofhh = request.mainincomesourceofhh;
                    entity.otherincomesource = request.otherincomesource;
                    entity.secondincomesourceofhh = request.secondincomesourceofhh;
                    entity.othersecondincomesource = request.othersecondincomesource;
                    entity.didhhreceivemonetaryhelp = request.didhhreceivemonetaryhelp;
                    entity.howmanytimesreceivedmonhelp = request.howmanytimesreceivedmonhelp;
                    entity.amountreceivedinlastoneyear = request.amountreceivedinlastoneyear;
                    entity.hashhcollectedanyaidinoneyear = request.hashhcollectedanyaidinoneyear;
                    entity.freequencyofaidreceived = request.freequencyofaidreceived;
                    entity.otherfreequencyofaidreceived = request.otherfreequencyofaidreceived;
                    entity.organizationtype = request.organizationtype;
                    entity.aidids = request.aidids;
                    entity.orgtypeids = request.orgtypeids;
                    entity.otheraid = request.otheraid;
                    entity.otherorgtype = request.otherorgtype;
                    
                    entity.createdby = request.createdby;
                    entity.apptypeid = request.apptypeid;
                    retval = await _iHouseholdService.AddIncomeSource(entity);
                    objIncomeList.status = retval.ToString();
                    objIncomeList.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
                }
            }
            catch (Exception ex)
            {
                objIncomeList.status = "500";
                objIncomeList.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objIncomeList.errorMessage = ex.Message;
            }
            return objIncomeList;

        }
    }
}
