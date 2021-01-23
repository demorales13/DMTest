using DMTest.Domain.Interface;
using DMTest.Domain.Interface.Repositories;
using DMTest.Infrastructure.Data.Repositories;

using System.Threading.Tasks;

namespace DMTest.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DMTestContext _context;

        public IUserRepository Users { get; }
        public IRouletteRepository Roulettes { get; }
        public IBetRepository Bets { get; }

        public UnitOfWork(DMTestContext context)
        {
            _context = context;

            Users = new UserRepository(_context);
            Roulettes = new RouletteRepository(_context);
            Bets = new BetRepository(_context);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
