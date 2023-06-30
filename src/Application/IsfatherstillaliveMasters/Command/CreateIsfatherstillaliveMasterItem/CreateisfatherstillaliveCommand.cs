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

namespace SRIS.Application.IsfatherstillaliveMasters.Command.CreateIsfatherstillaliveMasterItem
{
    public class CreateisfatherstillaliveCommand:IRequest<int>
    {
        public int id { get; set; }
        public string isfatherstillalive { get; set; }
        public string description { get; set; }
    }
public class CreateisfatherstillaliveCommandHandler : IRequestHandler<CreateisfatherstillaliveCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTime _datetime;

    public CreateisfatherstillaliveCommandHandler(IApplicationDbContext context, IDateTime datetime)
    {
        _context = context;
        _datetime = datetime;
    }

    public async Task<int> Handle(CreateisfatherstillaliveCommand request, CancellationToken cancellationToken)
    {
        Regex rgx = new Regex("[^A-Za-z ]");
        var entity = new Isfatherstillalive();
        int count = 0;
        int retval = 0;
        try
        {
            count = _context.m_master_isfatherstillalive.Where(x => x.isfatherstillalive == request.isfatherstillalive && x.deletedflag == false).Count();
            if (count == 0)
            {
                if (request.id == 0)
                {
                    // int id = _context.m_master_gender.ToListAsync().Result.LastOrDefault().genderid;
                    entity.isfatherstillalive = request.isfatherstillalive;
                    entity.description = request.description;
                    entity.createdby = 1;
                    entity.createdon = _datetime.Now;
                    entity.deletedflag = false;
                    bool hasSpecialChars = rgx.IsMatch(entity.isfatherstillalive);
                    if (entity.description != "")
                    {
                        bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                        if (hasSpecialChars == false && hasSpecialChars1 == false)
                        {
                            _context.m_master_isfatherstillalive.Add(entity);

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

                        _context.m_master_isfatherstillalive.Add(entity);

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

