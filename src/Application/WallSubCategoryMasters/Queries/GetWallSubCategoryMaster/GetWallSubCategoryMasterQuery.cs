using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.WallSubCategoryMasters.Queries.GetWallSubCategoryMaster
{
    public class GetWallSubCategoryMasterQuery : IRequest<WallSubCategoryMasterVM>
    {
        public int subcategoryid { get; set; }
    }
    public class GetWallSubCategoryMasterQueryHandler : IRequestHandler<GetWallSubCategoryMasterQuery, WallSubCategoryMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetWallSubCategoryMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<WallSubCategoryMasterVM> Handle(GetWallSubCategoryMasterQuery request, CancellationToken cancellationToken)
        {
            List<WallSubCategoryMasterVM> list = new List<WallSubCategoryMasterVM>();
            if (request.subcategoryid == 0)
            {
                return new WallSubCategoryMasterVM
                {
                    Lists = await _context.m_master_wallsubcategory.Join(_context.m_master_wallcategory
                                , SubCategory => SubCategory.categoryid
                                , Category => Category.categoryid
                                , (SubCategory, Category) => new { SubCategory, Category }).Where(x => x.SubCategory.deletedflag == false)
                                 .Select(s => new WallSubCategoryMasterDto
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

            else {
                return new WallSubCategoryMasterVM
                {
                    Lists = await _context.m_master_wallsubcategory.Join(_context.m_master_wallcategory
                                    , SubCategory => SubCategory.categoryid
                                    , Category => Category.categoryid
                                    , (SubCategory, Category) => new { SubCategory, Category }).Where(x => x.SubCategory.subcategoryid == request.subcategoryid && x.SubCategory.deletedflag == false)
                                     .Select(s => new WallSubCategoryMasterDto
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
        }
    }
}

