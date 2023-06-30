using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.UMUserLocationMasterItem.Queries.GetUMUserLocationMasterItem;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.UMUserLocationMasterItem.Command.DeleteUMUserLocationMaster
{
    public class DeleteUMUserLocationMasterCommand: IRequest<int>
    {
        public int userlocid { get; set; }
        public int userid { get; set; }
    }
    public class DeleteUMUserLocationMasterCommandHandler : IRequestHandler<DeleteUMUserLocationMasterCommand,int>
    {
        private readonly IUserLocationService _iuslocService;
        private readonly IApplicationDbContext _context;
        public DeleteUMUserLocationMasterCommandHandler(IUserLocationService iuslocService, IApplicationDbContext context)
        {
            _iuslocService = iuslocService;
            _context = context;
        }

        
        public async Task<int> Handle(DeleteUMUserLocationMasterCommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
            var entity1 = _context.t_user_userlocation.Where(s => s.userid == request.userid).ToList();
            if (entity1 == null)
            {
                throw new NotFoundException(nameof(UMUserLocation), request.userid);
            }
            foreach(var ent in entity1)
            {
                retval = await _iuslocService.deleteloc(ent.userlocid);
            }
          

            return retval;
        }
    }
}
