using DMTest.Domain.Entities;
using DMTest.Domain.Interface.Repositories;
using DMTest.Infrastructure.Data.Repositories.Base;

using Microsoft.EntityFrameworkCore;

namespace DMTest.Infrastructure.Data.Repositories
{
    public class BetRepository : Repository<Bet>, IBetRepository
    {
        public BetRepository(DbContext context) : base(context)
        {

        }
    }
}
