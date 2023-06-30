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

namespace SRIS.Application.MainJobActivityMaster.Commands.CreateMainJobActivityMaster
{
   public class CreateMainJobActivityCommand:IRequest<int>
    {
        public int activityid { get; set; }
        public string activityname { get; set; }
        public string description { get; set; }
    }
    public class CreateMainJobActivityCommandHandler : IRequestHandler<CreateMainJobActivityCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public CreateMainJobActivityCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(CreateMainJobActivityCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new MainJobActivity();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_mainjobactivity.Where(x => x.activityname == request.activityname && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.activityid == 0)
                    {
                        entity.activityname = request.activityname;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.createdon = _dateTime.Now;
                        entity.deletedflag = false;
                        entity.activityid = request.activityid;
                        bool hasSpecialChars = rgx.IsMatch(entity.activityname);
                        if (entity.description != "")
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_mainjobactivity.Add(entity);

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

                            _context.m_master_mainjobactivity.Add(entity);

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
