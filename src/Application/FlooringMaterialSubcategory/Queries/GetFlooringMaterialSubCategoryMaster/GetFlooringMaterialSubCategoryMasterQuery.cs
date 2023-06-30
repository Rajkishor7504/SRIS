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

namespace SRIS.Application.FlooringMaterialSubcategory.Queries.GetFlooringMaterialSubCategoryMaster
{
   public class GetFlooringMaterialSubCategoryMasterQuery : IRequest<FlooringMaterialSubCategoryMasterVM>
    {
        public int subcategoryid { get; set; }
    }
    public class GetRoffingMaterialSubCategoryMasterQueryHandler : IRequestHandler<GetFlooringMaterialSubCategoryMasterQuery, FlooringMaterialSubCategoryMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRoffingMaterialSubCategoryMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<FlooringMaterialSubCategoryMasterVM> Handle(GetFlooringMaterialSubCategoryMasterQuery request, CancellationToken cancellationToken)
        {
            List<FlooringMaterialSubCategoryMasterVM> list = new List<FlooringMaterialSubCategoryMasterVM>();
            if (request.subcategoryid == 0)
            {
                return new FlooringMaterialSubCategoryMasterVM
                {
                    Lists = await _context.m_master_flooringmaterialsubcategory.Join(_context.m_master_flooringmaterialcategory
                                , SubCategory => SubCategory.categoryid
                                , Category => Category.categoryid
                                , (SubCategory, Category) => new { SubCategory, Category }).Where(x => x.SubCategory.deletedflag == false)
                                 .Select(s => new FlooringMaterialSubCategoryMasterDto
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
                return new FlooringMaterialSubCategoryMasterVM
                {
                    Lists = await _context.m_master_flooringmaterialsubcategory.Join(_context.m_master_flooringmaterialcategory
                                    , SubCategory => SubCategory.categoryid
                                    , Category => Category.categoryid
                                    , (SubCategory, Category) => new { SubCategory, Category }).Where(x => x.SubCategory.subcategoryid == request.subcategoryid && x.SubCategory.deletedflag == false)
                                     .Select(s => new FlooringMaterialSubCategoryMasterDto
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
