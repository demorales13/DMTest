namespace DMTest.Domain.Entities
{
    public class Bet
    {
        public int BetId { get; set; }
        public decimal BetAmount { get; set; }
        public int Number { get; set; }

        // Navigation properties
        public int UserId { get; set; }
        public User User { get; set; }

        public int RouletteId { get; set; }
        public Roulette Roulette { get; set; }
    }
}