using System.ComponentModel.DataAnnotations;

namespace DMTest.Domain.Entities
{
    public class Roulette
    {
        public Roulette()
        {

        }

        [Key]
        public int RouletteId { get; set; }

        public int Status { get; set; }
    }
}
