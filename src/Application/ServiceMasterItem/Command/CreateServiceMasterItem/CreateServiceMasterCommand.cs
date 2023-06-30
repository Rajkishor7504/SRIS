using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.ServiceMasterItem.Command.CreateServiceMasterItem
{
    public  class CreateServiceMasterCommand : IRequest<int>
    {
        public int serviceid { get; set; }
        public string servicename { get; set; }
    }
    public class CreateServiceMasterCommandHandler : IRequestHandler<CreateServiceMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateServiceMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateServiceMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new ServicesMaster();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_services.Where(x => x.servicename == request.servicename && x.deleteflag == false).Count();
                if (count == 0)
                {
                    if (request.serviceid == 0)
                    {
                        entity.servicename = request.servicename;
                        entity.createdby = 1;
                        entity.updatedby = 1;
                        entity.deleteflag = false;
                        entity.serviceid = request.serviceid;
                        bool hasSpecialChars = rgx.IsMatch(entity.servicename);
                        

                        if (hasSpecialChars == false)
                        {

                            _context.m_master_services.Add(entity);
                            await _context.SaveChangesAsync(cancellationToken);
                            retval = 1;
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

