using SRIS.Application.OrganizationResistration.Queries.GetOrganization;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
    public interface IOrganizationService
    {
        Task<int> AddOrganization(OrganizationDto organization);
        Task<int> Partnernotification(OrganizationDto organization);

        Task<List<OrganizationDto>> GetOrganization();
        Task<OrganizationDto> GetOrganizationById(int? organizationId);
        Task<int> DeleteOrganization(int? organizationId);
        Task<int> ApproveOrRejectOrganization(OrganizationDto organization);
        Task<int> ApproveOrganization(int? organizationId);
    }
}
