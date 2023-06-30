using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.WallSubCategoryMasters.Queries.GetWallSubCategoryMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.RoffingMaterialSubcategory.Queries.GetRoffingMaterialSubCategoryMaster
{
   public class GetRoffingMaterialSubCategoryMasterQuery : IRequest<RoffingMaterialSubCategoryMasterVM>
    {
        public int subcategoryid { get; set; }
    }
    public class GetRoffingMaterialSubCategoryMasterQueryHandler : IRequestHandler<GetRoffingMaterialSubCategoryMasterQuery, RoffingMaterialSubCategoryMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRoffingMaterialSubCategoryMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<RoffingMaterialSubCategoryMasterVM> Handle(GetRoffingMaterialSubCategoryMasterQuery request, CancellationToken cancellationToken)
        {
            List<RoffingMaterialSubCategoryMasterVM> list = new List<RoffingMaterialSubCategoryMasterVM>();
            if (request.subcategoryid == 0)
            {
                return new RoffingMaterialSubCategoryMasterVM
                {
                    Lists = await _context.m_master_roffingmaterialsubcategory.Join(_context.m_master_roffingmaterialcategory
                                , SubCategory => SubCategory.categoryid
                                , Category => Category.categoryid
                                , (SubCategory, Category) => new { SubCategory, Category }).Where(x => x.SubCategory.deletedflag == false)

                                 .Select(s => new RoffingMaterialSubCategoryMasterDto
                                 {
                                     subcategoryid = s.SubCategory.subcategoryid,
                                     subcategoryname = s.SubCategory.subcategoryname,
                                     categoryid = s.SubCategory.categoryid,
                                     categoryname = s.Category.categoryname

                                 })
                                
                        .OrderBy(t => t.subcategoryname)
                        .ToListAsync(cancellationToken)
                };
            }

            else
            {
                return new RoffingMaterialSubCategoryMasterVM
                {
                    Lists = await _context.m_master_roffingmaterialsubcategory.Join(_context.m_master_roffingmaterialcategory
                                    , SubCategory => SubCategory.categoryid
                                    , Category => Category.categoryid
                                    , (SubCategory, Category) => new { SubCategory, Category }).Where(x => x.SubCategory.subcategoryid == request.subcategoryid && x.SubCategory.deletedflag == false)
                                  
                                     .Select(s => new RoffingMaterialSubCategoryMasterDto
                                     {
                                         subcategoryid = s.SubCategory.subcategoryid,
                                         subcategoryname = s.SubCategory.subcategoryname,
                                         categoryid = s.SubCategory.categoryid,
                                         categoryname = s.Category.categoryname

                                     })
                                     //.Where(t => t.deletedflag == false)
                            .OrderBy(t => t.subcategoryname)
                            .ToListAsync(cancellationToken)
                };
            }
        }
    }
}

