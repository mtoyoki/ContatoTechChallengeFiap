using Domain.Queries.Contato;
using Domain.Queries.EventMessage;
using Domain.Repositories;

namespace Application.Queries.Contato
{
    public class EventMessageQueryHandler(IEventMessageRepository repository) : IEventMessageQueryHandler
    {
        public Task<EventMessageQueryResult?> GetByEventMsgIdAsync(Guid eventMsgId)
        {
            return repository.GetByEventMsgIdAsync(eventMsgId);
        }
    }

    public interface IEventMessageQueryHandler
    {
        Task<EventMessageQueryResult?> GetByEventMsgIdAsync(Guid eventMsgId);
    }
}