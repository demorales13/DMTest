using DMTest.Domain.Exceptions;

using System.Collections.Generic;
using System.Linq;

namespace DMTest.Domain.Enum
{
    public class BetStatuses
    {
        public static readonly BetStatuses PENDING = new BetStatuses(0, nameof(PENDING));
        public static readonly BetStatuses WON = new BetStatuses(1, nameof(WON));
        public static readonly BetStatuses LOST = new BetStatuses(2, nameof(LOST));

        public int StatusId { get; private set; }
        public string Name { get; private set; }

        private BetStatuses(int statusId, string name)
        {
            StatusId = statusId;
            Name = name;
        }

        public static IReadOnlyCollection<BetStatuses> Get()
        {
            return new[] { PENDING, WON, LOST };
        }

        public static BetStatuses FindBy(int statusId)
        {
            var state = Get().SingleOrDefault(s => s.StatusId == statusId);
            if (state == null)
            {
                var values = Get().Select(x => x.StatusId);
                throw new DMTestException($"Valor invalido {nameof(BetStatuses)} {statusId}. {string.Join(",", values)}");
            }

            return state;
        }
    }
}
