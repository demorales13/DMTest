using DMTest.Domain.Entities;
using DMTest.Domain.Enum;
using DMTest.Domain.Exceptions;
using DMTest.Domain.Interface;
using DMTest.Domain.Interface.Services;

using System;
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
                throw new DMTestNotFoundException("No se encontraron ruletas");
            }

            return roulettes;
        }

        public async Task<IEnumerable<Roulette>> GetOpenAsync()
        {
            var roulettes = await _unitOfWork.Roulettes.GetAsync(
                x => x.Status == RouletteStatuses.OPENED.StatusId);

            if (roulettes == null)
            {
                throw new DMTestNotFoundException("No se encontraron ruletas abiertas");
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

        public async Task<Roulette> CloseAsync(int rouletteId)
        {
            var roulette = await _unitOfWork.Roulettes.FindAsync(rouletteId);
            roulette.WinnerNumber = GenerateWinnerNumber();
            roulette.Status = RouletteStatuses.CLOSED.StatusId;

            var bets = await _unitOfWork.Bets.GetAsync(x => x.RouletteId == rouletteId);
            foreach (var bet in bets)
            {
                var betEdited = await _unitOfWork.Bets.FindAsync(bet.BetId);
                ValidateBet(betEdited, roulette);
                if(betEdited.Status == BetStatuses.WON.StatusId)
                {
                    var user = await _unitOfWork.Users.FindAsync(betEdited.UserId);
                    user.Balance = user.Balance + (decimal)betEdited.Prize;
                }
            }
            await _unitOfWork.SaveChangesAsync();

            return await _unitOfWork.Roulettes.GetSingleAsync(x => x.RouletteId == rouletteId,
                                                                   i => i.Bets);
        }

        public async Task OpenAsync(int rouletteId)
        {
            var roulette = await _unitOfWork.Roulettes.FindAsync(rouletteId);

            if (roulette == null)
            {
                throw new DMTestNotFoundException("No se encontró la ruleta");
            }

            roulette.Status = RouletteStatuses.OPENED.StatusId;
            await _unitOfWork.SaveChangesAsync();
        }

        private int GenerateWinnerNumber()
        {
            Random random = new Random();
            return random.Next(0, 36);
        }

        private void ValidateBet(Bet bet, Roulette roulette)
        {
            bet.Status = BetStatuses.LOST.StatusId;

            if (bet.Number != null && roulette.WinnerNumber == bet.Number)
            {
                bet.Status = BetStatuses.WON.StatusId;
                bet.Prize = bet.BetAmount * BetPrizes.NUMBER.Prize;
            }

            if (bet.Color != null)
            {
                var winnerColor = BetColors.FindByNumber((int)roulette.WinnerNumber);
                var betColor = BetColors.FindById((int)bet.Color);

                if(winnerColor.StatusId == betColor.StatusId)
                {
                    bet.Status = BetStatuses.WON.StatusId;
                    bet.Prize = bet.BetAmount * BetPrizes.COLOR.Prize;
                }
            }
        }
    }
}
