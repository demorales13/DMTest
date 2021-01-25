using DMTest.Domain.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMTest.Domain.Interface.Services
{
    public interface IRouletteService
    {
        Task<Roulette> CloseAsync(int rouletteId);
        Task<Roulette> CreateAsync();
        Task<IEnumerable<Roulette>> GetOpenAsync();
        Task OpenAsync(int rouletteId);
        Task<IEnumerable<Roulette>> GetAsync();
    }
}