using DMTest.Domain.Entities;
using DMTest.Domain.Enum;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMTest.Domain.Interface.Services
{
    public interface IRouletteService
    {
        Task ChangeStatusAsync(int rouletteId, RouletteStatuses status);
        Task CloseAsync(int rouletteId);
        Task<Roulette> CreateAsync();
        Task<IEnumerable<Roulette>> GetOpenAsync();
        Task OpenAsync(int rouletteId);
        Task<IEnumerable<Roulette>> GetAsync();
    }
}