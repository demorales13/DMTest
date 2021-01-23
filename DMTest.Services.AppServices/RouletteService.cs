using DMTest.Domain.Entities;
using DMTest.Domain.Enum;
using DMTest.Domain.Exceptions;
using DMTest.Domain.Interface;
using DMTest.Domain.Interface.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMTest.Services.AppServices
{
    public class RouletteService : IRouletteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RouletteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Roulette>> GetAsync()
        {
            var roulettes = await _unitOfWork.Roulettes.GetAsync(includes: i => i.Bets);

            if (roulettes == null)
            {
                throw new TestNotFoundException("No se encontró el recurso");
            }

            return roulettes;
        }

        public async Task<IEnumerable<Roulette>> GetOpenAsync()
        {
            var roulettes = await _unitOfWork.Roulettes.GetAsync(
                x => x.Status == RouletteStatuses.OPENED.StatusId);

            if (roulettes == null)
            {
                throw new TestNotFoundException("No se encontró el recurso");
            }

            return roulettes;
        }

        public async Task<Roulette> CreateAsync()
        {
            var roulette = new Roulette
            {
                Status = RouletteStatuses.PENDING.StatusId
            };
            await _unitOfWork.Roulettes.AddAsync(roulette);
            await _unitOfWork.SaveChangesAsync();
            return roulette;
        }

        public async Task CloseAsync(int rouletteId)
        {
            await ChangeStatusAsync(rouletteId, RouletteStatuses.CLOSED);
        }

        public async Task OpenAsync(int rouletteId)
        {
            await ChangeStatusAsync(rouletteId, RouletteStatuses.OPENED);
        }

        public async Task ChangeStatusAsync(int rouletteId, RouletteStatuses status)
        {
            var roulette = await _unitOfWork.Roulettes.FindAsync(rouletteId);

            if (roulette == null)
            {
                throw new TestNotFoundException("No se encontró el recurso");
            }

            roulette.Status = status.StatusId;
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
