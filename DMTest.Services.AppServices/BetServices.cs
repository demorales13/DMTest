using DMTest.Domain.Entities;
using DMTest.Domain.Exceptions;
using DMTest.Domain.Interface;
using DMTest.Domain.Interface.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMTest.Services.AppServices
{
    public class BetServices : IBetServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public BetServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Bet> CreateByColorAsync(Bet bet, int rouletteId)
        {
            var roulette = await _unitOfWork.Roulettes.FindAsync(rouletteId);
            if (roulette == null)
            {
                throw new TestNotFoundException("No se encontró el recurso");
            }
            roulette.Bets.Add(bet);
            await _unitOfWork.SaveChangesAsync();
            return bet;
        }


        public async Task<IEnumerable<Bet>> GetByRouletteIdAsync(int rouletteId)
        {
            var bets = await _unitOfWork.Bets
                .GetAsync(x => x.RouletteId == rouletteId);

            if (bets == null)
            {
                throw new TestNotFoundException("No se encontró el recurso");
            }

            return bets;
        }
    }
}
