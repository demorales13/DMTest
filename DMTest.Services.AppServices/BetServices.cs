using DMTest.Domain.Entities;
using DMTest.Domain.Enum;
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

        public async Task<Bet> CreateAsync(Bet bet, int rouletteId)
        {
            var hasEnoughBalance = await ValidateUserBalance(bet);
            if (!hasEnoughBalance)
            {
                throw new TestException("El usuario no tiene saldo suficiente");
            }

            var roulette = await _unitOfWork.Roulettes.FindAsync(rouletteId);
            if (roulette == null)
            {
                throw new TestNotFoundException("La ruleta no existe");
            }

            if (roulette.Status != RouletteStatuses.OPENED.StatusId)
            {
                throw new TestException("La ruleta no se encuentra abierta");
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
    
    
        private async Task<bool> ValidateUserBalance(Bet bet)
        {
            var user = await _unitOfWork.Users.FindAsync(bet.UserId);
            if (user == null)
            {
                throw new TestNotFoundException("El usuario no existe");
            }

            if(user.Balance < bet.BetAmount)
            {
                return false;
            }

            user.Balance = user.Balance - bet.BetAmount;

            return true;
        }
    }
}
