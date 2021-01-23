using DMTest.Domain.Interface.Repositories;

using System.Threading.Tasks;

namespace DMTest.Domain.Interface
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IRouletteRepository Roulettes { get; }
        IBetRepository Bets { get; }

        bool SaveChanges();
        Task<bool> SaveChangesAsync();
    }
}
