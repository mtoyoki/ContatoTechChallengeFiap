using Core.Repositories;
using Domain.Entities;
using Domain.Queries.EventMessage;

namespace Domain.Repositories
{
    public interface IEventMessageRepository : IRepository<EventMessage>
    {
        Task<EventMessageQueryResult> GetByEventMsgIdAsync(Guid eventMsgId);

    }
}