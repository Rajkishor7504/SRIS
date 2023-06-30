﻿using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterDepenciesEntities;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.DiseaseMasters.Commands.DeleteDiseaseMasterItem
{
    public class DeleteDiseaseCommand:IRequest<int>
    {
        public int diseaseid { get; set; }
    }
    public class DeleteDiseaseCommandHandler : IRequestHandler<DeleteDiseaseCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteDiseaseCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteDiseaseCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_disease.FindAsync(request.diseaseid);
            try
            {
                count = _context.t_hhr_chronicediseasedetails.Where(x => x.diseaseid == request.diseaseid && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Chronicediseasedetails), request.diseaseid);
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
        //public async Task<Unit> Handle(DeleteDiseaseCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.m_master_disease.FindAsync(request.diseaseid);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(Disease), request.diseaseid);
        //    }

        //    _context.m_master_disease.Remove(entity);

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Unit.Value;
        //}
    }
}

