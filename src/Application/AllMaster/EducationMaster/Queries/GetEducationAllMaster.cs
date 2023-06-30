/*
* File Name : GetEducationAllMaster.cs
* class Name : GetEducationAllMaster, GetDistanceAlMasterHandler
* Created Date : 16th June 2021
* Created By : Rajalaxmi behera
* Description : Query to get the Education Related All Master records
*/
using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.AllMaster.EducationMaster.Queries
{
    public class GetEducationAllMaster : IRequest<EducationMasterVM>
    {
        public int id { get; set; }

    }
    public class GetEducationAllMasterHandler : IRequestHandler<GetEducationAllMaster, EducationMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IEducationMasterService _educationMasterService;

        public GetEducationAllMasterHandler(IApplicationDbContext context, IMapper mapper, IEducationMasterService educationMasterService)
        {
            _context = context;
            _mapper = mapper;
            _educationMasterService = educationMasterService;
        }

        #region "To get the Education Master records"

        public async Task<EducationMasterVM> Handle(GetEducationAllMaster request, CancellationToken cancellationToken)
        {
            EducationMasterVM model = new EducationMasterVM();
            model.neverAttendSchool = await _educationMasterService.GetNeverAttendSchoolData();
            model.levelGrade = await _educationMasterService.GetGradeData();
            model.stopGoingScl = await _educationMasterService.GetReasonForStopSchoolData();

            //newly added 22-05-23 

            model.schoolattended = await _educationMasterService.GetTypeOfSchoolAttendedData();
            model.levelGradecompleted = await _educationMasterService.GetLevelCompletedData();
            model.readwrite = await _educationMasterService.GetTypeOfReadWriteData();
            return model;
        }
        #endregion
    }
}
