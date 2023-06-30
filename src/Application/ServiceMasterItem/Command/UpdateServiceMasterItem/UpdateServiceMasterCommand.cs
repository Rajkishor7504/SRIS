using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.ServiceMasterItem.Command.UpdateServiceMasterItem
{
    public class UpdateServiceMasterCommand : IRequest<int>
    {
        public int serviceid { get; set; }
        public string servicename { get; set; }
    }
    public class UpdateServiceMasterCommandHandler : IRequestHandler<UpdateServiceMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateServiceMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateServiceMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_services.FindAsync(request.serviceid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(ServicesMaster), request.servicename);
                }
                count = _context.m_master_services.Where(x => x.servicename == request.servicename && x.serviceid != request.serviceid && x.deleteflag == false).Count();

                if (count == 0)
                {
                    if (request.serviceid != 0)
                    {
                        entity.servicename = request.servicename;
                       
                        bool hasSpecialChars = rgx.IsMatch(entity.servicename);
                         if (hasSpecialChars == false)
                        {

                            await _context.SaveChangesAsync(cancellationToken);
                            retval = 2;
                        }
                        else
                        {
                            retval = 403;


                        }
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

