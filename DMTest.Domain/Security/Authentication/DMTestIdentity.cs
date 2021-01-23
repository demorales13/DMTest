using Microsoft.AspNetCore.Http;

namespace DMTest.Domain.Security.Authentication
{
    public class DMTestIdentity
    {
        private readonly HttpContext _context;

        public DMTestIdentity(IHttpContextAccessor contextAccessor)
        {
            _context = contextAccessor.HttpContext;
        }

        public int UserId
        {
            get
            {
                var userId = 0;
                if (_context != null)
                {
                    if (_context.Request != null)
                    {
                        int.TryParse(_context.Request.Headers["userId"], out userId);
                    }
                }
                return userId;
            }
        }
    }

}
