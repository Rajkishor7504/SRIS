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

namespace SRIS.Application.FlooringMaterialSubcategory.Commands.CreateFlooringMaterialSubCategoryMasterList
{
   public class CreateFlooringMaterialSubCategoryMasterCommand : IRequest<int>
    {
        public int subcategoryid { get; set; }
        public int categoryid { get; set; }
        public string subcategoryname { get; set; }
    }
    public class CreateFlooringMaterialSubCategoryMasterCommandHandler : IRequestHandler<CreateFlooringMaterialSubCategoryMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateFlooringMaterialSubCategoryMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateFlooringMaterialSubCategoryMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new FlooringMaterialSubCategory();
            int count = 0;
            int retval = 0;
            try

            {
               /// count = _context.m_master_flooringmaterialsubcategory.Where(x => x.categoryid == request.categoryid && x.subcategoryid == request.subcategoryid).Count();
                count = _context.m_master_flooringmaterialsubcategory.Where(x => /*x.categoryid == request.categoryid &&*/ x.subcategoryname == request.subcategoryname && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.subcategoryid == 0)
                    {
                        entity.subcategoryname = request.subcategoryname;
                        entity.categoryid = request.categoryid;
                        entity.createdby = 1;
                        entity.updatedby = 1;
                        entity.deletedflag = false;
                        //entity.subcategoryid = request.subcategoryid;
                        entity.subcategoryid = _context.m_master_flooringmaterialsubcategory.Count() == 0 ? 1 : _context.m_master_flooringmaterialsubcategory.OrderByDescending(g => g.subcategoryid).FirstOrDefault().subcategoryid + 1;
                        bool hasSpecialChars = rgx.IsMatch(entity.subcategoryname);
                        if (hasSpecialChars == false)
                        {
                            _context.m_master_flooringmaterialsubcategory.Add(entity);
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