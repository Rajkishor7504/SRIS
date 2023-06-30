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

namespace SRIS.Application.AssetsMasterItem.Command.CreateAsstesMasterItem
{
    public class CreateAssetsMasterCommand : IRequest<int>
    {
        public int assetid { get; set; }
        public string Assetname { get; set; }
        public string description { get; set; }
    }
    public class CreateAssetsMasterCommandHandler : IRequestHandler<CreateAssetsMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateAssetsMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateAssetsMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new Assets();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_asset.Where(x => x.Assetname == request.Assetname && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.assetid == 0)
                    {
                        entity.Assetname = request.Assetname;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.updatedby = 1;
                        entity.deletedflag = false;
                        entity.assetid = request.assetid;
                        bool hasSpecialChars = rgx.IsMatch(entity.Assetname);
                        if (entity.description != "")
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_asset.Add(entity);
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

                            _context.m_master_asset.Add(entity);
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
