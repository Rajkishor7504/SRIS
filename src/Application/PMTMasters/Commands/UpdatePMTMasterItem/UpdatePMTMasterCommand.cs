using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.PMTMasters.Commands.UpdatePMTMasterItem
{
    public class UpdatePMTMasterCommand : IRequest<int>
    {
        public int categoryid { get; set; }
        public string category { get; set; }

        public Decimal min_value { get; set; }
        public Decimal max_value { get; set; }
    }
    public class UpdatePMTMasterCommandHandler : IRequestHandler<UpdatePMTMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePMTMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdatePMTMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.m_pmt_category.FindAsync(request.categoryid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(PmtMasterN), request.categoryid);
                }
                count = _context.m_pmt_category.Where(x => x.categoryid == request.categoryid && x.categoryid != request.categoryid && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.categoryid != 0)
                    {
                        entity.category = request.category;
                        entity.min_value = request.min_value;
                        entity.max_value = request.max_value;
                        await _context.SaveChangesAsync(cancellationToken);
                        retval = 2;
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
