using DMTest.Domain.Entities;

using System;
using System.Linq;

namespace DMTest.Infrastructure.Data.InicializeDatabase
{

    public class SeedDatabase
    {
        private DMTestContext _context;

        public SeedDatabase(DMTestContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            // Si ya hay data
            if (_context.Users.Any())
            {
                return;
            }

            _context.Users.AddRange(
                new User
                {
                    UserId = 1,
                    NickName = "Iron Man",
                    Balance = 15000
                },
                new User
                {
                    UserId = 2,
                    NickName = "Nick Fury",
                    Balance = 20000
                },
                new User
                {
                    UserId = 3,
                    NickName = "Spiderman",
                    Balance = 20000
                });

            _context.SaveChanges();
        }
    }
}
