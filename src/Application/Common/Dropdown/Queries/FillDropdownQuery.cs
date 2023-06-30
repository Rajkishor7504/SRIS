using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Dropdown.Queries
{
    public class FillDrodownQuery : IRequest<FillDropdownVM>
    {
        public string action { get; set; }
        public int item1 { get; set; }
        public int item2 { get; set; }

    }
    public class FillDrodownQueryHandler : IRequestHandler<FillDrodownQuery, FillDropdownVM>
    {
        private readonly ICommonService _iCommonService;
        private readonly IMapper _mapper;

        public FillDrodownQueryHandler(ICommonService iCommonService, IMapper mapper)
        {
            _iCommonService = iCommonService;
            _mapper = mapper;
        }

        public async Task<FillDropdownVM> Handle(FillDrodownQuery request, CancellationToken cancellationToken)
        {
            FillDropdownVM objVM = new FillDropdownVM();
            try
            {

                objVM.Lists = await _iCommonService.GetDropdownData(request);
                objVM.Lists.Insert(0, new FillDropdownDto() { idfield = 0, namefield = "-Select-" });
                objVM.status = "200";
                objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)200);

            }

            catch (Exception ex)
            {
                objVM.Lists = null;
                objVM.status = "500";
                objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objVM.errorMessage = ex.Message;
            }
            return objVM;


        }
    }
}
