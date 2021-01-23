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

        public async Task<IEnumerable<Roulette>> GetActivesAsync()
        {
            var empleados = await _unitOfWork.Roulettes.GetAsync(
                x => x.Status == RouletteStatuses.ACTIVE.StatusId);

            if (empleados == null)
            {
                throw new TestNotFoundException("No se encontraron empleados");
            }

            return empleados;
        }

        public async Task<Roulette> CreateAsync()
        {
            var roulette = new Roulette();
            await _unitOfWork.Roulettes.AddAsync(roulette);
            return roulette;
        }

        public async Task CloseAsync(int rouletteId)
        {
            var roulette = await _unitOfWork.Roulettes.FindAsync(rouletteId);
            roulette.Status = RouletteStatuses.CLOSED.StatusId;
            await _unitOfWork.SaveChangesAsync();
        }

    }
}
