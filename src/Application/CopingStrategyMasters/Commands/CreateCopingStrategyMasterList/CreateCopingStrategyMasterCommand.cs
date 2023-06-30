using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.CopingStrategyMasters.Queries.GetCopingStrategyMaster
{
    public class CreateCopingStrategyMasterCommand : IRequest<int>
    {
        public int copingid { get; set; }
        public string copingname { get; set; }
        public string description { get; set; }
        public int copingtypeid { get; set; }
        public int createdby { get; set; }
        public string action { get; set; }
    }
    public class CreateCopingStrategyMasterCommandHandler : IRequestHandler<CreateCopingStrategyMasterCommand, int>
    {
        private readonly ICopingStrategyMasterService _iCopingStaregy;
        private readonly IMapper _mapper;

        public CreateCopingStrategyMasterCommandHandler(ICopingStrategyMasterService iCopingStaregy, IMapper mapper)
        {
            _iCopingStaregy = iCopingStaregy;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCopingStrategyMasterCommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
                try
                {
                    var entity = new CopingStrategyMasterDto();

                    entity.action = request.action;
                    entity.copingid = request.copingid;
                    entity.copingname = request.copingname;
                    entity.description = request.description;
                    entity.copingtypeid = request.copingtypeid;
                    entity.createdby = request.createdby;

                    retval = await _iCopingStaregy.AddCopingStartegyMaster(entity);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            return retval;
        }
    }
}