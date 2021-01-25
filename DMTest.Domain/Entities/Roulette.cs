using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMTest.Domain.Entities
{
    public class Roulette
    {
        public Roulette()
        {
            Bets = new HashSet<Bet>();
        }

        [Key]
        public int RouletteId { get; set; }

        public int? WinnerNumber { get; set; }

        public int Status { get; set; }


        // Navegation properties
        public virtual ICollection<Bet> Bets { get; set; }
    }
}
