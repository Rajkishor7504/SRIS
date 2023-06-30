using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.TransportationModeMasters.Commands.CreateTransportationModeList;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.TransportationModeMasters.Commands.CreateTransportationModeList
{
   public class CreateTransportationModeMasterCommand : IRequest<int>
    {
        public int modeid { get; set; }
        public string modename { get; set; }
        public string description { get; set; }
    }
 
    public class CreateTransportationModeMasterCommandHandler : IRequestHandler<CreateTransportationModeMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTransportationModeMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateTransportationModeMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new TransportationMode();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_transportationmode.Where(x => x.modename == request.modename && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.modeid == 0)
                    {
                        entity.modename = request.modename;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.updatedby = 1;
                        entity.deletedflag = false;
                        entity.modeid = request.modeid;
                        bool hasSpecialChars = rgx.IsMatch(entity.modename);
                        if (entity.description != null)
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_transportationmode.Add(entity);
                                await _context.SaveChangesAsync(cancellationToken);
                                retval = 1;
                            }
                            else
                            {
                                retval = 403;
                            }
                        }

                        else if (hasSpecialChars == false)
                        {

                            _context.m_master_transportationmode.Add(entity);
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