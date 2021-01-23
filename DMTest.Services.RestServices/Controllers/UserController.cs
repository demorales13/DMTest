using DMTest.Domain.Exceptions;
using DMTest.Domain.Interface.Services;
using DMTest.Services.RestServices.Helpers;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Threading.Tasks;

namespace DMTest.Services.RestServices.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _environment;
        private readonly IUserServices _userService;

        public UserController(
            IUserServices UserService,
            IWebHostEnvironment environment,
            ILogger<UserController> logger)
        {
            _logger = logger;
            _environment = environment;
            _userService = UserService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
                return ResponseHelper.BadRequest(ModelState);

            try
            {
                var users = await _userService.GetAsync();
                return ResponseHelper.Ok(users);
            }
            catch (TestNotFoundException ex)
            {
                return ResponseHelper.NotFound(ex);
            }
            catch (TestException ex)
            {
                return ResponseHelper.BadRequest(ex);
            }
            catch (TestAuthException ex)
            {
                return ResponseHelper.BadRequest(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return ResponseHelper.BadRequest(ex);
            }
        }

    }
}
