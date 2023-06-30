using SRIS.Domain.Common;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
