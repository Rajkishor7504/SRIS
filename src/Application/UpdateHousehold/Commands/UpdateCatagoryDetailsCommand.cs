using MediatR;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.UpdateHousehold.Commands
{
    public class UpdateCatagoryDetailsCommand : IRequest<int>
    {
        [Key]
        public int updcatagorydetailsid { get; set; }
        public int requestid { get; set; }
        public int updatecategoryid { get; set; }
    }
    public class UpdateCatagoryDetailsCommandHandler : IRequestHandler<UpdateCatagoryDetailsCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public UpdateCatagoryDetailsCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        public Task<int> Handle(UpdateCatagoryDetailsCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
