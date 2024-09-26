using Domain.Entities;
using Domain.Queries.EventMessage;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class EventMessageRepository(ApplicationDbContext context) : RepositoryBase<EventMessage>(context), IEventMessageRepository
    {
        public async Task<EventMessageQueryResult?> GetByEventMsgIdAsync(Guid eventMsgId)
        {
            return await _context.EventMessage
                                    .Where(e => e.EventMsgId == eventMsgId)
                                    .Select(e => new EventMessageQueryResult(e.EventMsgId, e.EventMsg, e.Result, e.Details))
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync();
        }

        //private static EventMessageQueryResult EventMessageQueryResult(EventMessage e) => new EventMessageQueryResult(e.EventMsgId, e.EventMsg, e.Result, e.Details);
    }
}