using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.DataSharing.Queries
{
    public class DataSharingQuery : IRequest<DataSharingVM>
    {
        public string programcode { get; set; }
        public string lga { get; set; }
        public string district { get; set; }
        public string ward { get; set; }
        public string town { get; set; }
        public bool restdatarequired { get; set; }
    }
    public class DataSharingQueryHandler : IRequestHandler<DataSharingQuery, DataSharingVM>
    {

        private readonly IMapper _mapper;
        private readonly IDatasharingService _idatasharingService;

        public DataSharingQueryHandler(IMapper mapper, IDatasharingService idatasharingService)
        {

            _mapper = mapper;
            _idatasharingService = idatasharingService;
        }

        public async Task<DataSharingVM> Handle(DataSharingQuery request, CancellationToken cancellationToken)
        {

            DataSharingVM objvm = new DataSharingVM();
            try
            {
                if (request.restdatarequired == false)
                {
                    objvm.householdlist = await _idatasharingService.DatasharingList(request);
                    if(objvm.householdlist.Count != 0) {
                        objvm.status = "600";
                        objvm.message = CommonHelper.GetEnumDescription((ResponseStatus)600);
                        objvm.errorMessage = "";
                    }
                    else
                    {
                        objvm.status = "601";
                        objvm.message = CommonHelper.GetEnumDescription((ResponseStatus)601);
                        objvm.errorMessage ="Failure";
                    }
                    
                }
                else
                {
                    objvm.resthouseholddatalist = await _idatasharingService.HouseholdrestdataList(request);
                    if (objvm.resthouseholddatalist.Count != 0)
                    {
                        objvm.status = "600";
                        objvm.message = CommonHelper.GetEnumDescription((ResponseStatus)600);
                        objvm.errorMessage = "";
                    }
                    else
                    {
                        objvm.status = "601";
                        objvm.message = CommonHelper.GetEnumDescription((ResponseStatus)601);
                        objvm.errorMessage = "Failure";
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objvm;


        }



    }
}
