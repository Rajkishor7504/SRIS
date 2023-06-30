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

namespace SRIS.Application.AssetsMasterItem.Command.UpdateAssetsMasterItem
{
    public class UpdateAssetsMasterCommand : IRequest<int>
    {
        public int assetid { get; set; }
        public string Assetname { get; set; }
        public string description { get; set; }
    }
    public class UpdateAssetsMasterCommandHandler : IRequestHandler<UpdateAssetsMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateAssetsMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateAssetsMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_asset.FindAsync(request.assetid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Assets), request.Assetname);
                }
                count = _context.m_master_asset.Where(x => x.Assetname == request.Assetname && x.assetid != request.assetid && x.deletedflag == false).Count();

                if (count == 0)
                {
                    if (request.assetid != 0)
                    {
                        entity.Assetname = request.Assetname;
                        entity.description = request.description;

                        bool hasSpecialChars = rgx.IsMatch(entity.Assetname);
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
