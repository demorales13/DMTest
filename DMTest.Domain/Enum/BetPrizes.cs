using DMTest.Domain.Exceptions;

using System.Collections.Generic;
using System.Linq;

namespace DMTest.Domain.Enum
{
    public class BetPrizes
    {
        public static readonly BetPrizes NUMBER = new BetPrizes(0, nameof(NUMBER), 5);
        public static readonly BetPrizes COLOR = new BetPrizes(1, nameof(COLOR), 1.8m);

        public int StatusId { get; private set; }
        public string Name { get; private set; }
        public decimal Prize { get; private set; }

        private BetPrizes(int statusId, string name, decimal prize)
        {
            StatusId = statusId;
            Name = name;
            Prize = prize;
        }

        public static IReadOnlyCollection<BetPrizes> Get()
        {
            return new[] { COLOR, NUMBER };
        }

        public static BetPrizes FindById(int statusId)
        {
            var state = Get().SingleOrDefault(s => s.StatusId == statusId);
            if (state == null)
            {
                var values = Get().Select(x => x.StatusId);
                throw new DMTestException($"Valor invalido {nameof(BetPrizes)} {statusId}. {string.Join(",", values)}");
            }

            return state;
        }
    }
}
