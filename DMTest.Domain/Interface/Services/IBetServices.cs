using DMTest.Domain.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMTest.Domain.Interface.Services
{
    public interface IBetServices
    {
        Task<IEnumerable<Bet>> GetByRouletteId(int rouletteId);
    }
}