using Core.Entity;
using Core.Repository;
using Infrastructure.Database;

namespace Infrastructure.Repository
{
    public class DddRepository : EFRepository<Ddd>, IDddRepository
    {
        public DddRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}