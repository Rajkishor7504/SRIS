
/*
* File Name : GetAgricultureMasterQuery.cs
* class Name : GetAgricultureMasterQuery, GetAgricultureMasterHandler
* Created Date : 17th June 2021
* Created By : Rajalaxmi behera
* Description : Query to get the Agriculture Master records
*/
using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IMaster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.AllMaster.AgriculturalMasterAPI.Queries.GetAgricultureMaster
{
   public class GetAgricultureMasterQuery : IRequest<AgricultureMasterVM>
    {
        public int id { get; set; }
    }
    public class GetAgricultureMasterHandler : IRequestHandler<GetAgricultureMasterQuery, AgricultureMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAgriculturalMasterService _agriculturalMasterService;

        public GetAgricultureMasterHandler(IApplicationDbContext context, IMapper mapper, IAgriculturalMasterService agriculturalMasterService)
        {
            _context = context;
            _mapper = mapper;
            _agriculturalMasterService = agriculturalMasterService;
        }

        #region "To get the Education Master records"

        public async Task<AgricultureMasterVM> Handle(GetAgricultureMasterQuery request, CancellationToken cancellationToken)
        {
            AgricultureMasterVM model = new AgricultureMasterVM();
            model.livestock = await _agriculturalMasterService.GetlivestockData();
            model.crop = await _agriculturalMasterService.GetCropData();
            model.breeding = await _agriculturalMasterService.GetBreedingData();
            //added on 22-03-23
            model.ecology = await _agriculturalMasterService.GetEcologyData();
            return model;
        }
        #endregion
    }
}
