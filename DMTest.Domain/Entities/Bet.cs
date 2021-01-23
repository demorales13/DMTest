using System.ComponentModel.DataAnnotations;

namespace DMTest.Domain.Entities
{
    public class Bet
    {
        [Key]
        public int BetId { get; set; }
        public decimal BetAmount { get; set; }
        public int Number { get; set; }
        public int Color { get; set; }

        // Navigation properties
        public int UserId { get; set; }
        public User User { get; set; }

        public int RouletteId { get; set; }
        public Roulette Roulette { get; set; }
    }
}