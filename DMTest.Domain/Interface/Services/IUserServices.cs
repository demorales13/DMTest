using DMTest.Domain.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMTest.Domain.Interface.Services
{
    public interface IUserServices
    {
        Task<IEnumerable<User>> GetAsync();
    }
}