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

namespace SRIS.Application.PurposeMaster.Commands.CreatePurposeMasterList
{
    public class CreatePurposeMasterCommand : IRequest<int>
    {
        public int purposeid { get; set; }
        public string purposename { get; set; }
        public string description { get; set; }
    }
    public class CreatePurposeMasterCommandHandler : IRequestHandler<CreatePurposeMasterCommand, int>
    {
        private readonly IDateTime _dateTime;
        private readonly IApplicationDbContext _context;

        public CreatePurposeMasterCommandHandler(IApplicationDbContext context,IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }
        public async Task<int> Handle(CreatePurposeMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new Purpose();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_purpose.Where(x => x.purposename == request.purposename && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.purposeid == 0)
                    {
                        entity.purposename = request.purposename;
                        entity.description = request.description;
                        entity.createdby = 1;
                        //entity.updatedby = 1;
                        entity.deletedflag = false;
                        entity.createdon = _dateTime.Now;
                        entity.purposeid = request.purposeid;
                        bool hasSpecialChars = rgx.IsMatch(entity.purposename);
                        if (entity.description != null)
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_purpose.Add(entity);
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

                            _context.m_master_purpose.Add(entity);
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