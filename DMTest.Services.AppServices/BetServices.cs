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

        public async Task<IEnumerable<Bet>> GetByRouletteId(int rouletteId)
        {
            var bets = await _unitOfWork.Bets
                .GetAsync(x => x.RouletteId == rouletteId);

            if (bets == null)
                throw new TestNotFoundException("No se encontraron apuestas");

            return bets;
        }
    }
}
