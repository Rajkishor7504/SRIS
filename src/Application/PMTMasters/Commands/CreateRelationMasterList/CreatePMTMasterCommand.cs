using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.PMTMasters.Commands.CreateRelationMasterList
{
    public class CreatePMTMasterCommand : IRequest<int>
    {
        public int categoryid { get; set; }
        public string category { get; set; }
        public int min_value { get; set; }
        public int max_value { get; set; }
        public Boolean deletedflag { get; set; }
    }
    public class CreatePMTMasterCommandHandler : IRequestHandler<CreatePMTMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreatePMTMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePMTMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = new PmtMasterN();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_pmt_category.Where(x => x.categoryid == request.categoryid && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.categoryid == 0)
                    {
                        entity.category = request.category;
                        entity.min_value = request.min_value;
                        entity.max_value = request.max_value;
                        entity.createdby = 1;
                        entity.updatedby = 1;
                        entity.deletedflag = false;
                        entity.categoryid = request.categoryid;
                        _context.m_pmt_category.Add(entity);

                        await _context.SaveChangesAsync(cancellationToken);
                        retval = 1;
                    }
                }
                else
                {
                    retval = 3;
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



