using DMTest.Domain.Exceptions;

using System.Collections.Generic;
using System.Linq;

namespace DMTest.Domain.Enum
{
    public class RouletteStatuses
    {
        public static readonly RouletteStatuses ACTIVE = new RouletteStatuses(1, nameof(ACTIVE));
        public static readonly RouletteStatuses CLOSED = new RouletteStatuses(2, nameof(CLOSED));

        public int StatusId { get; private set; }
        public string Name { get; private set; }

        private RouletteStatuses(int statusId, string name)
        {
            StatusId = statusId;
            Name = name;
        }

        public static IReadOnlyCollection<RouletteStatuses> Get()
        {
            return new[] { CLOSED, ACTIVE };
        }

        public static RouletteStatuses FindBy(int statusId)
        {
            var state = Get().SingleOrDefault(s => s.StatusId == statusId);
            if (state == null)
            {
                var values = Get().Select(x => x.StatusId);
                throw new TestException($"Valor invalido {nameof(RouletteStatuses)} {statusId}. {string.Join(",", values)}");
            }

            return state;
        }
    }
}
