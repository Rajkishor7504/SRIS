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

namespace SRIS.Application.ConfigureCommiteeMasterItems.Commands.UpdateConfigureCommitee
{
    public class UpdateConfigureCommiteeCommand:IRequest<int>
    {
        public int configureid { get; set; }
        public string commiteename { get; set; }
        public int noofcommiteemembers { get; set; }
        public int createdby { get; set; }
    }
    public class UpdateConfigureCommiteeCommandHandler : IRequestHandler<UpdateConfigureCommiteeCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;
    
        public UpdateConfigureCommiteeCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;

        }
        public async Task<int> Handle(UpdateConfigureCommiteeCommand request, CancellationToken cancellationToken)
        {
            Regex rgx1 = new Regex("[^0-9 ]");
            var entity = await _context.m_grievance_configurecomittee.FindAsync(request.configureid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(ConfigureCommitee), request.commiteename);
                }
                count = _context.m_grievance_configurecomittee.Where(x => x.commiteename == request.commiteename && x.configureid != request.configureid).Count();
                if (count == 0)
                {
                    if (request.configureid != 0)
                    {
                        //entity.commiteename = request.commiteename;
                        entity.noofcommiteemembers = request.noofcommiteemembers;
                        entity.updatedby = request.createdby;
                        entity.updatedon = _dateTime.Now;
                        bool hasSpecialChars = rgx1.IsMatch(entity.noofcommiteemembers.ToString());
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