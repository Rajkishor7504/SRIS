using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Exceptions;
using SRIS.Domain.Entities;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Grievances.Commands.CreateConfigureCommitee
{
    public class CreateConfigureCommiteeCommand : IRequest<int>
    {
        public int configureid { get; set; }
        public string commiteename { get; set; }
        public int noofcommiteemembers { get; set; }
        public int createdby { get; set; }
      
    }
    public class CreateConfigureCommiteeCommandHandler : IRequestHandler<CreateConfigureCommiteeCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateConfigureCommiteeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateConfigureCommiteeCommand request, CancellationToken cancellationToken)
        {
            Regex rgx1 = new Regex("[^0-9 ]");
            var entity = new ConfigureCommitee();
            int count = 0;
            int retval = 0;
            try
                {
                count = _context.m_grievance_configurecomittee.Where(x => x.commiteename == request.commiteename).Count();
                if (count == 0)
                {
                    entity.configureid = request.configureid;
                    entity.commiteename = request.commiteename;
                    entity.noofcommiteemembers = request.noofcommiteemembers;
                    entity.configureid = 0;
                    entity.createdby = request.createdby;
                    bool hasSpecialChars = rgx1.IsMatch(entity.noofcommiteemembers.ToString());
                    if (hasSpecialChars == false)
                    {

                        _context.m_grievance_configurecomittee.Add(entity);

                        await _context.SaveChangesAsync(cancellationToken);
                        retval = 1;
                    }
                    else
                    {
                        retval = 403;


                    }

                }
                else
                {
                    retval = 3;
                }
            }
            catch (Exception ex)
            {
                throw new DuplicateRecordFoundException(nameof(request), count);
            }


            return retval;
        }
    }
}
