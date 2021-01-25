using DMTest.Domain.Exceptions;

using System.Collections.Generic;
using System.Linq;

namespace DMTest.Domain.Enum
{
    public class BetColors
    {
        public static readonly BetColors RED = new BetColors(0, nameof(RED));
        public static readonly BetColors BLACK = new BetColors(1, nameof(BLACK));

        public int StatusId { get; private set; }
        public string Name { get; private set; }

        private BetColors(int statusId, string name)
        {
            StatusId = statusId;
            Name = name;
        }

        public static IReadOnlyCollection<BetColors> Get()
        {
            return new[] { BLACK, RED };
        }

        public static BetColors FindById(int statusId)
        {
            var state = Get().SingleOrDefault(s => s.StatusId == statusId);
            if (state == null)
            {
                var values = Get().Select(x => x.StatusId);
                throw new TestException($"Valor invalido {nameof(BetColors)} {statusId}. {string.Join(",", values)}");
            }

            return state;
        }

        public static BetColors FindByNumber(int number)
        {
            if (IsEvenNumber(number))
            {
                return BetColors.RED;
            }

            return BetColors.BLACK;
        }

        private static bool IsEvenNumber(int number)
        {
            return (number % 2) == 0;
        }
    }
}
