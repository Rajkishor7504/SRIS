using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using SRIS.Domain.Entities.MasterDepenciesEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.GradeLevelMasters.Commands.DeleteGradeLevelMaster
{
    public class DeleteGradeCommand: IRequest<int>
    {
        public int gradeid { get; set; }
    }
    public class DeleteGradeCommandHandler : IRequestHandler<DeleteGradeCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteGradeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteGradeCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_grade.FindAsync(request.gradeid);
            try
            {
                count = _context.t_hhr_education.Where(x => x.c06_grade == request.gradeid && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Education), request.gradeid);
                }
                if (count > 0)
                {
                    retval = 402;
                }
                else
                {
                    entity.updatedby = 1;
                    entity.deletedflag = true;
                    await _context.SaveChangesAsync(cancellationToken);
                    retval = 200;
                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            //return Unit.Value;
            return retval;
        }
        //public async Task<Unit> Handle(DeleteGradeCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.m_master_grade.FindAsync(request.gradeid);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(GradeLevelMaster), request.gradeid);
        //    }

        //    _context.m_master_grade.Remove(entity);

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Unit.Value;
        //}
    }
  
}
