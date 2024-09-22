using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class EventMessageRepository : RepositoryBase<EventMessage>, IEventMessageRepository
    {
        public EventMessageRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}