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

namespace SRIS.Application.RoffingMaterialSubcategory.Commands.UpdateRoffingMaterialSubCategoryMasterItem
{
   public class UpdateRoffingMaterialSubCategoryMasterCommand : IRequest<int>
    {
        public int subcategoryid { get; set; }
        public int categoryid { get; set; }
        public string subcategoryname { get; set; }
       
    }
    public class UpdateRoffingMaterialSubCategoryMasterCommandHandler : IRequestHandler<UpdateRoffingMaterialSubCategoryMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateRoffingMaterialSubCategoryMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateRoffingMaterialSubCategoryMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_roffingmaterialsubcategory.FindAsync(request.subcategoryid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(RoffingMaterialSubCategory), request.subcategoryid);
                }
                count = _context.m_master_roffingmaterialsubcategory.Where(x => x.subcategoryname == request.subcategoryname && x.subcategoryid != request.subcategoryid && x.deletedflag == false).Count();
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

