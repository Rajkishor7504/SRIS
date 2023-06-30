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

namespace SRIS.Application.LastLevelGradeMaster.Commands.UpdateLastLevelGradeTypeMasterItem
{
    public class UpdateLastLevelGradeTypeMasterCommand : IRequest<int>
    {
        public int lastlevelid { get; set; }
        public string lastlevelname { get; set; }
    }
    public class UpdateLastLevelGradeTypeMasterCommandHandler : IRequestHandler<UpdateLastLevelGradeTypeMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;


        public UpdateLastLevelGradeTypeMasterCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _dateTime = dateTime;
            _context = context;
        }
        public async Task<int> Handle(UpdateLastLevelGradeTypeMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_lastlevelgrade.FindAsync(request.lastlevelid);
            int count = 0;
            int retval = 0;

            if (entity == null)
            {
                throw new NotFoundException(nameof(LastLevelGradeMasterEntity), request.lastlevelname);
            }
            count = _context.m_master_lastlevelgrade.Where(x => x.lastlevelname == request.lastlevelname && x.lastlevelid != request.lastlevelid && x.deletedflag == false).Count();
            if (count == 0)
            {
                if (request.lastlevelid != 0)
                {
                    entity.updatedon = _dateTime.Now;
                    entity.updatedby = 1;
                    entity.lastlevelname = request.lastlevelname;
                    bool hasSpecialChars = rgx.IsMatch(entity.lastlevelname);
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

            return retval;
        }
    }
}
