using DMTest.Domain.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMTest.Domain.Interface.Services
{
    public interface IBetServices
    {
        Task<IEnumerable<Bet>> GetByRouletteIdAsync(int rouletteId);
        Task<Bet> CreateAsync(Bet bet, int rouletteId);
    }
}