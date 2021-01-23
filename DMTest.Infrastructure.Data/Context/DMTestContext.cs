using DMTest.Domain.Entities;
using DMTest.Infrastructure.Data.InicializeDatabase;

using Microsoft.EntityFrameworkCore;

namespace DMTest.Infrastructure.Data
{
    public class DMTestContext: DbContext
    {
        public DMTestContext(DbContextOptions<DMTestContext> options)
                : base(options)
        {
            if (Database.EnsureCreated())
            {
                var seed = new SeedDatabase(this);
                seed.Initialize();
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Roulette> Roulettes { get; set; }

    }
}
