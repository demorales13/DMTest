using DMTest.Domain.Entities;
using DMTest.Domain.Exceptions;
using DMTest.Domain.Interface;
using DMTest.Domain.Interface.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMTest.Services.AppServices
{
    public class UserServices : IUserServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetAsync()
        {
            var users = await _unitOfWork.Users
                .GetAsync();

            if (users == null)
                throw new TestNotFoundException("No se encontró el recurso");

            return users;
        }
    }
}
