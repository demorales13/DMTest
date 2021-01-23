using DMTest.Domain.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMTest.Domain.Interface.Services
{
    public interface IRouletteService
    {
        Task CloseAsync(int rouletteId);
        Task<Roulette> CreateAsync();
        Task<IEnumerable<Roulette>> GetActivesAsync();
    }
}