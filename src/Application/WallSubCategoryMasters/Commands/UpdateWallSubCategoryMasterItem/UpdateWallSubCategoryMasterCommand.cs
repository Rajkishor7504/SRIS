﻿using MediatR;
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

namespace SRIS.Application.WallSubCategoryMasters.Commands.UpdateWallSubCategoryMasterItem
{
    public class UpdateWallSubCategoryMasterCommand : IRequest<int>
    {
        public int subcategoryid { get; set; }
        public string subcategoryname { get; set; }
        public int categoryid { get; set; }
    }
    public class UpdateWallSubCategoryMasterCommandHandler : IRequestHandler<UpdateWallSubCategoryMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateWallSubCategoryMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateWallSubCategoryMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_wallsubcategory.FindAsync(request.subcategoryid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(WallSubCategory), request.subcategoryid);
                }
                count = _context.m_master_wallsubcategory.Where(x => x.subcategoryname == request.subcategoryname && x.subcategoryid != request.subcategoryid && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.subcategoryid != 0)
                    {
                        entity.subcategoryname = request.subcategoryname;
                        entity.categoryid = request.categoryid;

                        bool hasSpecialChars = rgx.IsMatch(entity.subcategoryname);
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

