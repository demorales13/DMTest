using DMTest.Domain.Entities;
using DMTest.Domain.Interface.Repositories;
using DMTest.Infrastructure.Data.Repositories.Base;

using Microsoft.EntityFrameworkCore;

namespace DMTest.Infrastructure.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {

        }
    }
}
