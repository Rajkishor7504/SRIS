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

namespace SRIS.Application.MainJobActivityMaster.Commands.UpdateMainJobActivityMaster
{
    public class UpdateMainJobActivityCommand:IRequest<int>
    {
        public int activityid { get; set; }
        public string activityname { get; set; }
        public string description { get; set; }
    }
    public class UpdateMainJobActivityCommandHandler : IRequestHandler<UpdateMainJobActivityCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _datetime;

        public UpdateMainJobActivityCommandHandler(IApplicationDbContext context, IDateTime datetime)
        {
            _context = context;
            _datetime=datetime;
        }

        public async Task<int> Handle(UpdateMainJobActivityCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_mainjobactivity.FindAsync(request.activityid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(MainJobActivity), request.activityname);
                }
                count = _context.m_master_mainjobactivity.Where(x => x.activityname == request.activityname && x.activityid != request.activityid && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.activityid != 0)
                    {
                        entity.activityname = request.activityname;
                        entity.description = request.description;
                        entity.updatedby = 1;
                        entity.updatedon = _datetime.Now;

                        bool hasSpecialChars = rgx.IsMatch(entity.activityname);
                        if (entity.description != null)
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                await _context.SaveChangesAsync(cancellationToken);
                                retval = 2;
                            }
                            else
                            {
                                retval = 403;
                            }
                        }

                        else if (hasSpecialChars == false)
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
